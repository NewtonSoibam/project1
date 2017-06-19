using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERP.Core.DataRepositoryLayer.PMS;
using ERP.Core.DataModel.PMS;

using System.Linq.Expressions;
using System.Data.Entity;
using System.Diagnostics;

namespace TestProject.PMS
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void InsertGraph()
        {


            DMM_ProjTransmittal projTransmittal = new DMM_ProjTransmittal();

            projTransmittal.ProjectID = 106;
            projTransmittal.TransmittalNo = 106;
            projTransmittal.IsAutoTransmittalNo = false;
            projTransmittal.TransmittalDate = DateTime.Today;
            projTransmittal.TransmittalAddressID = 75;
            projTransmittal.AddressTo = "Jame";
            projTransmittal.Designation = "-";
            projTransmittal.ProjClientAddressID = 84;
            projTransmittal.ProjClient = "Symphony Software";
            projTransmittal.Address1 = "";
            projTransmittal.Address2 = "";
            projTransmittal.Address3 = "";
            projTransmittal.City = "Bangalore";
            projTransmittal.PostalCode = "560025";
            projTransmittal.StateName = "Karnataka";
            projTransmittal.Country = "India";
            projTransmittal.MobileNo = "92342342342";
            projTransmittal.PhoneNo = "342342342342";
            projTransmittal.DeliveryModeID = 1;
            projTransmittal.DeliveryMode = "Courier";
            projTransmittal.Remarks = "";
            projTransmittal.CreatedBy = 1;

            projTransmittal.DMM_ProjTransMedium = new List<DMM_ProjTransMedium> {
                                    new DMM_ProjTransMedium {
                                        MediumID= 1,
                                        MediumName = "White Prints",
                                        MediumValue = true,
                                        CreatedBy = 1
                                    },
                                    new DMM_ProjTransMedium
                                    {
                                        MediumID= 2,
                                        MediumName = "Blue Prints",
                                        MediumValue = true,
                                        CreatedBy = 1
                                    }


            };

            projTransmittal.DMM_ProjTransDeliverableType = new List<DMM_ProjTransDeliverableType> {
                                    new DMM_ProjTransDeliverableType {
                                        DeliverableTypeID= 1,
                                        DeliverableType = "Scheme Drawings",
                                        DeliverableTypeValue = true,
                                        CreatedBy = 1
                                    }


            };

            projTransmittal.DMM_ProjTransPurpose = new List<DMM_ProjTransPurpose> {
                                    new DMM_ProjTransPurpose {
                                        PurposeID= 1,
                                        PurposeName = "For Approval",
                                        PurposeValue = true,
                                        CreatedBy = 1
                                    }


            };

            projTransmittal.DMM_ProjTransmittalItem = new List<DMM_ProjTransmittalItem>  {
                                                 new DMM_ProjTransmittalItem
                                                 {
                                                        ItemTypeID = 1,
                                                        ItemNo = "B1-A-2001",
                                                        ItemTitle = "Plinth Beam Marking Layout",
                                                        NosOfCopies = 67,
                                                        RevisionNo = "A",
                                                        ProjectDrawingID = 1289,
                                                        RevisionNoID = 1,
                                                        ItemOrder = 1,
                                                        CreatedBy = 1

                                                   }
            };




            using (var pmsDBContext = new PMSDBContextUOW())
            {
                using (var repo = new TransmittalRepository(pmsDBContext))
                {
                    repo.InsertOrUpdateGraph(projTransmittal);
                    pmsDBContext.Save();
                }
            }

            //using (var pmsDBContext = new PMSDBContextUOW())
            //{
            //    using (var repo = new TransmittalRepository(pmsDBContext))
            //    {
            //        repo.InsertOrUpdateGraph(projTransmittal);
            //        pmsDBContext.Save();
            //    }
            //}

            //                TransmittalID	ProjectID	TransmittalNo	IsAutoTransmittalNo	TransmittalDate	TransmittalAddressID	AddressTo	Designation	ProjClientAddressID	ProjClient	Address1	Address2	Address3	City	PostalCode	State	Country	MobileNo	PhoneNo	DeliveryModeID	DeliveryMode	Remarks	CreatedOn	CreatedBy	ModifiedOn	ModifiedBy	DeleteActive	DeletedOn	DeletedBy
            //271	106	13	1	2017-03-28 00:00:00.000	75	Jame	Project Manager	83	IGIB	10/2, O'Shaughnessy Road	Langford Gardens		Bangalore 	560025	Karnataka	India	9845480368/98454803689	NULL	3	Email		2017-03-28 11:23:40.890	1	NULL	NULL	0	NULL	NULL

            //string vTransmittalAddressID = gvShippingAddresses.DataKeys[gvrow.RowIndex].Values["TransmittalAddressID"].ToString();
            //objProjTransmittal.TransmittalAddressID = long.Parse(vTransmittalAddressID);

            //DataTable dtProjectShippingAddress = objProjectTransmittalService.SelectProjTransmittalAddress(long.Parse(vTransmittalAddressID));
            //if (dtProjectShippingAddress.Rows.Count >= 0)
            //{
            //    objProjTransmittal.AddressTo = dtProjectShippingAddress.Rows[0]["AddressTo"].ToString();
            //    objProjTransmittal.Designation = dtProjectShippingAddress.Rows[0]["Designation"].ToString();
            //    objProjTransmittal.ProjClientAddressID = long.Parse(dtProjectShippingAddress.Rows[0]["ProjClientAddressID"].ToString());
            //    objProjTransmittal.ProjClient = dtProjectShippingAddress.Rows[0]["ProjClient"].ToString();
            //    objProjTransmittal.Address1 = dtProjectShippingAddress.Rows[0]["Address1"].ToString();
            //    objProjTransmittal.Address2 = dtProjectShippingAddress.Rows[0]["Address2"].ToString();
            //    objProjTransmittal.Address3 = dtProjectShippingAddress.Rows[0]["Address3"].ToString();
            //    objProjTransmittal.City = dtProjectShippingAddress.Rows[0]["City"].ToString();
            //    objProjTransmittal.PostalCode = dtProjectShippingAddress.Rows[0]["PostalCode"].ToString();
            //    objProjTransmittal.State = dtProjectShippingAddress.Rows[0]["State"].ToString();
            //    objProjTransmittal.Country = dtProjectShippingAddress.Rows[0]["Country"].ToString();
            //    objProjTransmittal.MobileNo = dtProjectShippingAddress.Rows[0]["MobileNo"].ToString();
            //    objProjTransmittal.PhoneNo = dtProjectShippingAddress.Rows[0]["PhoneNo"].ToString();
            //}



        }


        [TestMethod]
        public void UpdateGraph()
        {

            BL objBL = new BL();


            DMM_ProjTransmittal projTransmittal = objBL.GetTransmittal(281);

            projTransmittal.State = ObjectState.State.Modified;
            projTransmittal.Address1 = "Addres1";



            DMM_ProjTransmittalItem ProjTransmittalItem = objBL.GetTransmittalItem(7214);

            ProjTransmittalItem.State = ObjectState.State.Modified;
            ProjTransmittalItem.ItemTitle = "Newton";
            ProjTransmittalItem.ModifiedBy = 1;

            projTransmittal.DMM_ProjTransmittalItem = new List<DMM_ProjTransmittalItem>  {ProjTransmittalItem

            };


            using (var pmsDBContext = new PMSDBContextUOW())
            {
                using (var repo = new TransmittalRepository(pmsDBContext))
                {
                    repo.InsertOrUpdateGraph(projTransmittal);
                    pmsDBContext.Save();
                }
            }

        }

        [TestMethod]
        public void UpdateGraphver2()
        {

            BL objBL = new BL();


            DMM_ProjTransmittal projTransmittal = objBL.GetTransmittalGraph(296);

            projTransmittal.State = ObjectState.State.Modified;
            projTransmittal.Address1 = "Bangalore";


            foreach (var item in projTransmittal.DMM_ProjTransmittalItem)
            {
                //  item.ItemTitle = "newton";
                item.State = ObjectState.State.Unchanged;
            }

            var item2 = projTransmittal.DMM_ProjTransmittalItem.SingleOrDefault(id => id.TransItemID == 7222);
            item2.ItemTitle = "newton";
            item2.ModifiedBy = 1;
            item2.State = ObjectState.State.Modified;


            foreach (var item in projTransmittal.DMM_ProjTransMedium)
            {
                //  item.MediumName = "";
                item.State = ObjectState.State.Unchanged;
            }

            foreach (var item in projTransmittal.DMM_ProjTransDeliverableType)
            {
                //  item.MediumName = "";
                item.State = ObjectState.State.Unchanged;
            }

            foreach (var item in projTransmittal.DMM_ProjTransPurpose)
            {
                //  item.MediumName = "";
                item.State = ObjectState.State.Unchanged;
            }



            //DMM_ProjTransmittalItem ProjTransmittalItem = objBL.GetTransmittalItem(7214);

            //ProjTransmittalItem.State = ObjectState.State.Modified;
            //ProjTransmittalItem.ItemTitle = "Newton";
            //ProjTransmittalItem.ModifiedBy = 1;

            //projTransmittal.DMM_ProjTransmittalItem = new List<DMM_ProjTransmittalItem>  {ProjTransmittalItem

            //};



            using (var pmsDBContext = new PMSDBContextUOW())
            {
                using (var repo = new TransmittalRepository(pmsDBContext))
                {
                    repo.InsertOrUpdateGraph(projTransmittal);
                    pmsDBContext.Save();
                }
            }

        }


        [TestMethod]
        public void BLCode()
        {

            BL objBL = new BL();






            //  var vNextTransmittalNo = objBL.GetNextTransmittalNo(1009);



            //using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            //{

            //    int vCompanyBranchID = 1;
            //    long vProjectID = 106;

            //    var vDeliveryModeIDs = new[] { 1, 2 };



            //    //var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //    //                ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
            //    //                .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
            //    //                .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //                .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //                .OrderBy(t => t.CreatedOn)
            //    //                .Select(t => new { t.TransmittalID, t.TransmittalNo, t.TransmittalDate, t.SignedProject.ProjectName,t.ProjectID,t.SignedProject.ProjectClient.ProjClient,t.SignedProject.Staff.StaffName, t.CreatedOn, t.AddressTo,t.DeliveryModeID,
            //    //                    t.DMM_ProjTransDeliveryMode.DeliveryMode, objBL.GetNextTransmittalNo(t.ProjectID) });

            //    //var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //    //                ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
            //    //                .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
            //    //              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //              .OrderBy(t => t.CreatedOn)
            //    //              .Select(t => new {
            //    //                  t.TransmittalID,
            //    //                  t.TransmittalNo,
            //    //                  t.TransmittalDate,
            //    //                  t.SignedProject.ProjectName,
            //    //                  t.ProjectID,
            //    //                  t.SignedProject.ProjectClient.ProjClient,
            //    //                  t.SignedProject.Staff.StaffName,
            //    //                  t.CreatedOn,
            //    //                  t.AddressTo,
            //    //                  t.DeliveryModeID,
            //    //                  t.DMM_ProjTransDeliveryMode.DeliveryMode,
            //    //                  objBL.GetNextTransmittalNo(t.ProjectID)
            //    //              });

            //   // var vReportData = new ReportData();

            //    //var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //    //                ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
            //    //                .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
            //    //               .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //               .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //               .OrderBy(t => t.CreatedOn)
            //    //               .Select(t => new ReportData
            //    //               {
            //    //                   TransmittalID = t.TransmittalID,                                  
            //    //                   TransmittalNo = objBL.GetNextTransmittalNo(t.ProjectID)
            //    //               });

            //    var query2 = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //                    ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
            //                    .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
            //                  .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //                  .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //                  .OrderBy(t => t.CreatedOn)
            //                  .Select(t => new
            //                  {
            //                      CreatedInfo = Repo.All.Count()
            //                  });



            //    var result = query2.ToList();

            //    //int total = 0; 
            //    //var firstPageData = objBL.PagedResult2(Repo.All, 2, 20, t => t.CreatedOn, false, out total);

            //    //var firstPageData2 = firstPageData.ToList();

            //}



            //    var articles = (from article in Articles
            //                where article.Author == "Abc"
            //                select article);


            //var firstPageData = PagedResult(articles, 1, 20, article => article.PublishedDate, false, out totalArticles);

            //var context = new AtricleEntityModel();
            //var query = context.ArticlesPagedResult(articles, < pageNumber >, 20, article => article.PublishedDate, false, out totalArticles);


        }


        [TestMethod]
        public void Query()
        {

            var PMSDBContext = new PMSDBContextUOW();

            //var query2 = (from t in PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals join s in PMSDBContext.GetPMSDBContextUOW.Staffs on t.CreatedBy equals s.UserID
            //              select new { t.TransmittalNo,s.StaffName });


            //var query3 = PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals
            //            .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID,
            //            (t, s) => new { t.TransmittalNo, s.StaffName })
            //            .Where(r => r.StaffName == "Newton") ;

            //var query4 = PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals
            //         .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID,
            //         (t, s) => new { t = t, s = s })
            //         .Where(r => r.s.StaffName == "Newton")
            //         .OrderBy(r => r.t.TransmittalDate);


            //var query5 = PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals
            //        .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID,
            //        (t, s) => new { t = t, s = s })
            //        .Where(r => r.s.StaffName == "Newton")
            //        .OrderBy(r => r.t.TransmittalDate);


            // left outer join 
            //var query6 = (from t in PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals
            //              join s in PMSDBContext.GetPMSDBContextUOW.Staffs on t.CreatedBy equals s.UserID into ts
            //              from s in ts.DefaultIfEmpty()
            //              select new { t.TransmittalNo, s.StaffName });


            // Right outer join 
            //var query7 = (from s in PMSDBContext.GetPMSDBContextUOW.Staffs 
            //              join t in PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals on s.UserID equals t.CreatedBy into ts
            //              from t in ts.DefaultIfEmpty()
            //              select new { t.TransmittalNo, s.StaffName });


            //var query8 = PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals
            //        .GroupJoin(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID,
            //        (t, s) => new { t = t, s = s.Select(y => y) });

            //var r = query8.ToList();


            //      var query9 = PMSDBContext.GetPMSDBContextUOW.Staffs
            //            .GroupJoin(PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals, t => t.UserID, s => s.CreatedBy,
            //            (t, s) => new { t.UserID, t.StaffName, s = s.Select(ss => new { ss.TransmittalNo, ss.TransmittalDate }) });

            //      var query10 = PMSDBContext.GetPMSDBContextUOW.Staffs
            //.GroupJoin(PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals, t => t.UserID, s => s.CreatedBy,
            //(t, s) => new { t = t.StaffName, s = s });

            using (var Repo = new TransmittalRepository(PMSDBContext))
            {

                int vCompanyBranchID = 1;
                long vProjectID = 106;

                var vDeliveryModeIDs = new[] { 1, 2 };



                var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
                    .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID, (t, s) => new
                    {
                        t.TransmittalID,
                        t.TransmittalNo,
                        t.TransmittalDate,
                        t.SignedProject.ProjectName,
                        t.ProjectID,
                        t.SignedProject.ProjectClient.ProjClient,
                        TL = t.SignedProject.Staff.StaffName,
                        t.CreatedOn,
                        t.AddressTo,
                        t.DeliveryModeID,
                        t.DMM_ProjTransDeliveryMode.DeliveryMode,
                        t.CreatedBy,
                        CreatedByName = s.StaffName
                    })
                    .Where(t => t.ProjectName.Contains("IGI"))
                  .Where(t => t.ProjClient.Contains("IGI"))
                  .OrderBy(t => t.CreatedOn);

                var query2 = Repo.All
                    .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID, (t, s) => new
                    {
                        t.TransmittalID,
                        t.TransmittalNo,
                        t.TransmittalDate,
                        t.ProjectID,
                        t.SignedProject.ProjectName,
                        t.SignedProject.ProjectClient.ProjClient,
                        TL = t.SignedProject.Staff.StaffName,
                        t.CreatedOn,
                        t.AddressTo,
                        t.DeliveryModeID,
                        t.DMM_ProjTransDeliveryMode.DeliveryMode,
                        t.CreatedBy,
                        CreatedByName = s.StaffName
                    })
                    .Where(t => t.ProjectName.Contains("IGI"))
                  .Where(t => t.ProjClient.Contains("IGI"))
                  .OrderBy(t => t.CreatedOn);


                var query3 = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
                              ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
                              .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
                              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                              .OrderBy(t => t.CreatedOn)
                              .Select(t => new
                              {
                                  t.TransmittalID,
                                  t.TransmittalNo,
                                  t.TransmittalDate,
                                  t.SignedProject.ProjectName,
                                  t.ProjectID,
                                  t.SignedProject.ProjectClient.ProjClient,
                                  t.SignedProject.Staff.StaffName,
                                  t.CreatedOn,
                                  t.AddressTo,
                                  t.DeliveryModeID,
                                  t.DMM_ProjTransDeliveryMode.DeliveryMode,

                                  CreatedbyName = "Newton"

                              });


                //var query5 = Repo.AllIncluding(t => t.SignedProject, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo);

                //var query5 = Repo.AllIncluding(t => t.SignedProject.ProjectClient);




                var r = query3.ToList();

                ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
                //    .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
                //.Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                //.Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                //.OrderBy(t => t.CreatedOn)
                //.Select(t => new
                //{
                //    t.TransmittalID,
                //    t.TransmittalNo,
                //    t.TransmittalDate,
                //    t.SignedProject.ProjectName,
                //    t.ProjectID,
                //    t.SignedProject.ProjectClient.ProjClient,
                //    t.SignedProject.Staff.StaffName,
                //    t.CreatedOn,
                //    t.AddressTo,
                //    t.DeliveryModeID,
                //    t.DMM_ProjTransDeliveryMode.DeliveryMode,
                //    t.CreatedBy
                //});


                //var fquery = Repo.All.Join(PMSDBContext.GetPMSDBContextUOW.Staffs, q => q.CreatedBy, s => s.UserID, (q, s) => new { q = q, s.StaffName });

                //   var r = query3.ToList();

            }

            // var r = query9.ToList();


            //       .Where(r => r.sStaffName == "Newton")
            //  .OrderBy(r => r.t.TransmittalDate);





            //var GroupPersons = this.Persons.GroupJoin(this.Addresses,     /// Inner Collection
            //                              p => p.IdAddress,   /// PK
            //                              a => a.IdAddress,   /// FK
            //                              (p, a) =>           /// Result Collection
            //                              new {
            //                                  MyPerson = p,
            //                                  Addresses = a.Select(ad => ad).ToList()
            //                              }).ToList();


            //var GroupAddresses = this.Addresses.GroupJoin(this.Persons,         /// Inner Collection
            //                                  a => a.IdAddress,     /// PK
            //                                  p => p.IdAddress,     /// FK
            //                                  (a, p) =>             /// Result Collection
            //                                  new {
            //                                      MyAddress = a,
            //                                      Persons = p.Select(ps => ps).ToList()
            //                                  }).ToList();

            //var resultJoint = Person.BuiltPersons().Join(                      /// Source Collection
            //                  Address.BuiltAddresses(),                        /// Inner Collection
            //                  p => p.IdAddress,                                /// PK
            //                  a => a.IdAddress,                                /// FK
            //                  (p, a) => new { MyPerson = p, MyAddress = a })   /// Result Collection
            //                  .Select(a => new
            //                  {
            //                      Name = a.MyPerson.Name,
            //                      Age = a.MyPerson.Age,
            //                      PersonIdAddress = a.MyPerson.IdAddress,
            //                      AddressIdAddress = a.MyAddress.IdAddress,
            //                      Street = a.MyAddress.Street
            //                  });


            //         var query = database.Posts    // your starting point - table in the "from" statement
            //.Join(database.Post_Metas, // the source table of the inner join
            //   post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
            //   meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
            //   (post, meta) => new { Post = post, Meta = meta }) // selection
            //.Where(postAndMeta => postAndMeta.Post.ID == id);


            // var q = query8.ToList();

            // var query = PMSDBContext.GetPMSDBContextUOW.DMM_ProjTransmittals.Join(PMSDBContext.GetPMSDBContextUOW.Staffs)

            //List<string> allCompanyName = new List<string>();
            ////using (MyDatabaseEntities dc = new MyDatabaseEntities())
            ////{
            ////    allCompanyName = (from a in dc.TopCompanies
            ////                      where a.CompanyName.StartsWith(pre)
            ////                      select a.CompanyName).ToList();
            ////}
            //for (int i = 0; i < 4; i++)
            //{
            //    allCompanyName.Add("Company " + i.ToString());
            //}

            //string vKeywords = "company";

            //var allCompanyName2 = allCompanyName.Where(c => c.ToLower().Contains(vKeywords.ToLower())).ToList();





            //            Posts.Join(
            //    Post_metas,
            //    post => post.Post_id,
            //    meta => meta.Post_id,
            //    (post, meta) => new { Post = post, Meta = meta }
            //)





        }

        [TestMethod]
        public void QuerySet2()
        {

            var PMSDBContext = new PMSDBContextUOW();

            var vtotal = PMSDBContext.GetPMSDBContextUOW.Staffs.Count();
            var q = PMSDBContext.GetPMSDBContextUOW.Staffs
                    .OrderBy(s => s.CreatedOn)
                    .Select(s => new
                    {
                        s.StaffName,
                        s.DepartmentID
                    }
                        )
                        .AsEnumerable()
                        .Select(t => new { t.StaffName, total = vtotal });

            var uuu = q.ToList();

            //var dd = PMSDBContext.GetPMSDBContextUOW.ProjectClients.Where(c => c.ProjectClientID == 1).Count();

            var q2 = (from s in PMSDBContext.GetPMSDBContextUOW.SignedProjects
                      select new
                      {
                          s.ProjectName,
                          s.ProjectClientID

                      }).AsEnumerable()
                      .Select(
                                r => new
                                {
                                    r.ProjectName,
                                    r.ProjectClientID,
                                    PClientName = (from c in PMSDBContext.GetPMSDBContextUOW.ProjectClients where c.ProjectClientID == r.ProjectClientID select new { c.ProjClient }).FirstOrDefault()

                                }
                            )
                     ;


            var yy = q2.ToList();

            foreach (var c in q2)
            {
                Debug.WriteLine("--------------------------------------------");

                Debug.WriteLine(string.Format("Dept Name - {0} {1} {2}", c.ProjectName, c.ProjectClientID, c.PClientName));

            }

            //using (var Repo = new TransmittalRepository(PMSDBContext))
            //{

            //    int vCompanyBranchID = 1;
            //    long vProjectID = 106;

            //    var vDeliveryModeIDs = new[] { 1, 2 };


            //    //var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //    //    .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID, (t, s) => new
            //    //    {
            //    //        t.TransmittalID,
            //    //        t.TransmittalNo,
            //    //        t.TransmittalDate,
            //    //        t.SignedProject.ProjectName,
            //    //        t.ProjectID,
            //    //        t.SignedProject.ProjectClient.ProjClient,
            //    //        TL = t.SignedProject.Staff.StaffName,
            //    //        t.CreatedOn,
            //    //        t.AddressTo,
            //    //        t.DeliveryModeID,
            //    //        t.DMM_ProjTransDeliveryMode.DeliveryMode,
            //    //        t.CreatedBy,
            //    //        CreatedByName = s.StaffName
            //    //    })
            //    //    .Where(t => t.ProjectName.Contains("IGI"))
            //    //  .Where(t => t.ProjClient.Contains("IGI"))
            //    //  .OrderBy(t => t.CreatedOn);

            //    //var query2 = Repo.All
            //    //    .Join(PMSDBContext.GetPMSDBContextUOW.Staffs, t => t.CreatedBy, s => s.UserID, (t, s) => new
            //    //    {
            //    //        t.TransmittalID,
            //    //        t.TransmittalNo,
            //    //        t.TransmittalDate,
            //    //        t.ProjectID,
            //    //        t.SignedProject.ProjectName,
            //    //        t.SignedProject.ProjectClient.ProjClient,
            //    //        TL = t.SignedProject.Staff.StaffName,
            //    //        t.CreatedOn,
            //    //        t.AddressTo,
            //    //        t.DeliveryModeID,
            //    //        t.DMM_ProjTransDeliveryMode.DeliveryMode,
            //    //        t.CreatedBy,
            //    //        CreatedByName = s.StaffName
            //    //    })
            //    //    .Where(t => t.ProjectName.Contains("IGI"))
            //    //   .Where(t => t.ProjClient.Contains("IGI"))
            //    //   .OrderBy(t => t.CreatedOn);

            //    //var t44 = query2.ToList();

            //    //var query3 = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
            //    //              ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
            //    //              .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
            //    //              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
            //    //              .OrderBy(t => t.CreatedOn)
            //    //              .Select(t => new
            //    //              {
            //    //                  t.TransmittalID,
            //    //                  t.TransmittalNo,
            //    //                  t.TransmittalDate,
            //    //                  t.SignedProject.ProjectName,
            //    //                  t.ProjectID,
            //    //                  t.SignedProject.ProjectClient.ProjClient,
            //    //                  t.SignedProject.Staff.StaffName,
            //    //                  t.CreatedOn,
            //    //                  t.AddressTo,
            //    //                  t.DeliveryModeID,
            //    //                  t.DMM_ProjTransDeliveryMode.DeliveryMode,

            //    //                 Total = PMSDBContext.GetPMSDBContextUOW.d.Count()

            //    //              });





            //    //  var r = query3.ToList();


            //}



        }


    }

    public class ReportData
    {

        public long TransmittalID { get; set; }
        public int TransmittalNo { get; set; }
    }

    public class BL
    {


        public int GetNextTransmittalNo(long projectID)
        {
            int vNextTransmittalNo = 0;
            int vStartingTransmittalNo = 1;

            using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            {
                var vTransmittalist = Repo.All.Where(t => t.ProjectID == projectID)
                                              .OrderByDescending(t => t.TransmittalNo)
                                              .First();

                if (vTransmittalist != null)
                {
                    vNextTransmittalNo = vTransmittalist.TransmittalNo + 1;

                    var vTransSettings = Repo.AllSettings.Where(s => s.ProjectID == projectID)
                                             .SingleOrDefault();


                    if (vTransSettings != null)
                    {
                        vStartingTransmittalNo = vTransSettings.StartingTransmittalNo;

                        if (vNextTransmittalNo <= vStartingTransmittalNo)
                            vNextTransmittalNo = vStartingTransmittalNo;
                    }


                }



            }

            return vNextTransmittalNo;

        }

        public DMM_ProjTransmittal GetTransmittal(int id)
        {
            using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            {
                return Repo.Find(id);
            }

        }

        public DMM_ProjTransmittal GetTransmittalGraph(long id)
        {
            using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            {
                //  var t2 = Repo.All.Where(c => c.TransmittalID == id).FirstOrDefault();
                // var t1 = Repo.AllIncluding(c => c.DMM_ProjTransmittalItem).Include(c => c.DMM_ProjTransMedium).Where(c => c.TransmittalID == id).FirstOrDefault();

                var t1 = Repo.AllIncluding(t => t.DMM_ProjTransmittalItem, t => t.DMM_ProjTransMedium, t => t.DMM_ProjTransDeliverableType, t => t.DMM_ProjTransPurpose).FirstOrDefault(c => c.TransmittalID == id);
                return t1;

            }

        }

        public DMM_ProjTransmittalItem GetTransmittalItem(int id)
        {
            using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            {
                return Repo.FindTransmittalItem(id);
            }

        }



        // <summary>
        /// Pages the specified query.
        /// </summary>
        /// <typeparam name="T">Generic Type Object</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The Object query where paging needs to be applied.</param>
        /// <param name="pageNum">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="orderByProperty">The order by property.</param>
        /// <param name="isAscendingOrder">if set to <c>true</c> [is ascending order].</param>
        /// <param name="rowsCount">The total rows count.</param>
        /// <returns></returns>
        private static IQueryable<T> PagedResult<T, TResult>(IQueryable<T> query, int pageNum, int pageSize,
                        Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder, out int rowsCount)
        {
            if (pageSize <= 0) pageSize = 20;

            //Total result count
            rowsCount = query.Count();

            //If page number should be > 0 else set to first page
            if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

            //Calculate nunber of rows to skip on pagesize
            int excludedRows = (pageNum - 1) * pageSize;

            query = isAscendingOrder ? query.OrderBy(orderByProperty) : query.OrderByDescending(orderByProperty);

            //Skip the required rows for the current page and take the next records of pagesize count
            return query.Skip(excludedRows).Take(pageSize);
        }

        public IQueryable<T> PagedResult2<T, TResult>(IQueryable<T> query, int pageNum, int pageSize,
                      Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder, out int rowsCount)
        {
            if (pageSize <= 0) pageSize = 20;

            //Total result count
            rowsCount = query.Count();

            //If page number should be > 0 else set to first page
            if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

            //Calculate nunber of rows to skip on pagesize
            int excludedRows = (pageNum - 1) * pageSize;

            query = isAscendingOrder ? query.OrderBy(orderByProperty) : query.OrderByDescending(orderByProperty);

            //Skip the required rows for the current page and take the next records of pagesize count
            return query.Skip(excludedRows).Take(pageSize);
        }
    }
}
