﻿using ElementMaterialsTechnology.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ElementMaterialsTechnology.Service
{
	public class QuotationService : AbstractServiceBase, IQuotationService
	{
		public QuotationService(TechTestContext techTestContext) : base(techTestContext) { }

		public IEnumerable<QuotationViewModel> AddQuotation(QuotationViewModel quotation)
		{
			return AddOrUpdateQuotation(quotation);
		}

		public IEnumerable<QuotationViewModel> GetQuotations()
		{
			try
			{
				var quotations = _techTestContext.QuotationDetails
												 .Join(_techTestContext.Quotations, qd => qd.QuotationNo, q => q.QuotationNo, (qd, q) => new { Quotation = q, QuotationDetail = qd })
												 .Join(_techTestContext.Customers, qvm => qvm.Quotation.CustomerId, c => c.CustomerId, (qvm, c) =>
														 new QuotationViewModel
														 {
															 QuotationNo = qvm.Quotation.QuotationNo,
															 QuotationDate = qvm.Quotation.QuotationDate,
															 Description = qvm.Quotation.Description,
															 Status = qvm.Quotation.Status,
															 Subject = qvm.Quotation.Subject,
															 Value = qvm.Quotation.Value,
															 Amount = qvm.QuotationDetail.Amount,
															 Price = qvm.QuotationDetail.Price,
															 ProdCode = qvm.QuotationDetail.ProdCode,
															 ProdName = qvm.QuotationDetail.ProdName,
															 Qty = qvm.QuotationDetail.Qty,
															 QuotationDetailId = qvm.QuotationDetail.Id,
															 CustomerId = qvm.Quotation.CustomerId,
															 CustomerName = c.CustomerName
														 });

				return quotations;
			}
			catch (Exception)
			{
				return Enumerable.Empty<QuotationViewModel>();
			}
		}

		public IEnumerable<QuotationViewModel> SearchQuotations(string customerId, DateTime? fromDate, DateTime? toDate)
		{
			SqlConnection dbConnection = (SqlConnection)_techTestContext.Database.GetDbConnection();

			using (SqlCommand cmd = new("SearchQuotations", dbConnection))
			{
				SqlDataAdapter adapt = new(cmd);
				adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.NVarChar));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.DateTime));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.DateTime));
				adapt.SelectCommand.Parameters["@CustomerId"].Value = customerId;
				adapt.SelectCommand.Parameters["@FromDate"].Value = fromDate;
				adapt.SelectCommand.Parameters["@ToDate"].Value = toDate;


				DataTable dt = new();
				_ = adapt.Fill(dt);

				return Enumerable.Empty<QuotationViewModel>();
			}
		}

		public IEnumerable<QuotationViewModel> UpdateQuotation(QuotationViewModel quotation)
		{
			return AddOrUpdateQuotation(quotation);
		}

		private IEnumerable<QuotationViewModel> AddOrUpdateQuotation(QuotationViewModel quotation)
		{
			SqlConnection dbConnection = (SqlConnection)_techTestContext.Database.GetDbConnection();

			using (SqlCommand cmd = new("AddOrUpdateQuotation", dbConnection))
			{
				SqlDataAdapter adapt = new(cmd);
				adapt.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapt.SelectCommand.Parameters.Add(new SqlParameter("@QuotationNo", SqlDbType.BigInt));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.NVarChar));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@ProdCode", SqlDbType.NVarChar));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal));
				adapt.SelectCommand.Parameters.Add(new SqlParameter("@QuotationDate", SqlDbType.Date));

				adapt.SelectCommand.Parameters["@QuotationNo"].Value = quotation.QuotationNo;
				adapt.SelectCommand.Parameters["@CustomerId"].Value = quotation.CustomerId;				
				adapt.SelectCommand.Parameters["@ProdCode"].Value = quotation.ProdCode;
				adapt.SelectCommand.Parameters["@Status"].Value = quotation.Status;
				adapt.SelectCommand.Parameters["@Qty"].Value = quotation.Qty;
				adapt.SelectCommand.Parameters["@QuotationDate"].Value = quotation.QuotationDate;



				DataTable dt = new();
				_ = adapt.Fill(dt);

				return Enumerable.Empty<QuotationViewModel>();
			}
		}
	}
}
