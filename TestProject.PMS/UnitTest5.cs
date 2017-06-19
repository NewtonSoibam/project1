using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERP.Core.DataRepositoryLayer.PMS;
using System.Linq;

namespace TestProject.PMS
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void KonnectQueries()
        {
            using (var Repo = new TransmittalRepository(new PMSDBContextUOW()))
            {

                int vCompanyBranchID = 1;
                long vProjectID = 106;

                var vDeliveryModeIDs = new[] { 1, 2 };

                var query = Repo.AllIncluding(t => t.SignedProject, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
                              ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
                              //.Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
                              //.Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                              .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                              .OrderBy(t => t.CreatedOn)
                              .Select(t => new
                              {
                                  t.TransmittalID,
                                  t.SignedProject.ProjectName,
                                  t.ProjectID,
                                  t.TransmittalNo,                               
                                  t.TransmittalDate,
                                  t.AddressTo,
                                  SendBy = t.DMM_ProjTransDeliveryMode.DeliveryMode,
                                  t.DeliveryModeID,
                                  TransmittalStatus = (((Int64?)t.DMM_ProjTransSendingInfo.TransmittalID ?? 0) == 0) ? ((((Int64?)t.DMM_ProjTransReceiptInfo.TransmittalID ?? 0) == 0) ? "Generated" : "Sent") : "Received",
                                  TransmittalStatusID = (((Int64?)t.DMM_ProjTransSendingInfo.TransmittalID ?? 0) == 0) ? ((((Int64?)t.DMM_ProjTransReceiptInfo.TransmittalID ?? 0) == 0) ? 1 : 2) : 3,
                                  CreatedOnD = t.CreatedOn,
                                  ModifiedOnD = t.ModifiedOn,
                                  IsAllowToEdit = "True",
                                  IsAllowToDelete = "False",
                                  CreationInfo = "Newton",
                                  ModifyInfo = "Newton",
                                  t.IsAutoTransmittalNo,
                                  IsAutoTransmittalNoToDisplay = (t.IsAutoTransmittalNo == true) ? "Auto" : "Manual",
                                  TransmittalDateInDateFormat = t.TransmittalDate,

                                  SendingInfoID = (Int64?)t.DMM_ProjTransSendingInfo.TransmittalID ?? 0,
                                  SendingInfo = (((Int64?)t.DMM_ProjTransSendingInfo.TransmittalID ?? 0) == 0) ? ((((Int64?)t.DMM_ProjTransReceiptInfo.TransmittalID ?? 0) == 0) ? "Generated" : "Sent") : "Received",
                                  ReceiptInfoID = (Int64?)t.DMM_ProjTransReceiptInfo.TransmittalID ?? 0
                                  //t.DMM_ProjTransSendingInfo.SentDate,
                                  //t.DMM_ProjTransReceiptInfo.ReceiptDate

                              })
                             ;


                var result = query.ToList();

                //        TransmittalID,-
                //ProjectName,-
                //DMM_ProjTransmittal.ProjectID,-
                //TransmittalNo,-
                //dbo.ufnProperDateByColumn(TransmittalDate) as TransmittalDate,-
                //AddressTo,-
                //DeliveryMode as SendBy,-
                //DeliveryModeID,-
                //           dbo.PMS_DMM_ufnGetTransmittalStatus(DMM_ProjTransmittal.TransmittalID) as TransmittalStatus,
                //dbo.PMS_DMM_ufnGetTransmittalStatusID(DMM_ProjTransmittal.TransmittalID) as TransmittalStatusID,
                //dbo.ufnProperDateByColumn(DMM_ProjTransmittal.CreatedOn) AS CreatedOnD,
                //               dbo.ufnProperDateByColumn(DMM_ProjTransmittal.ModifiedOn)AS ModifiedOnD,
                //               dbo.PMS_DMM_ufnIsAllowToEditTransmittal(DMM_ProjTransmittal.TransmittalID) AS IsAllowToEdit,
                //               dbo.PMS_DMM_ufnIsAllowToDeleteTransmittal(DMM_ProjTransmittal.TransmittalID) AS IsAllowToDelete,

                //               'Created : ' + dbo.ufnProperDateTimeByColumn(DMM_ProjTransmittal.CreatedOn) + ' - ' + dbo.ufnGetUserLoginIDByUserID(DMM_ProjTransmittal.CreatedBy)AS CreationInfo,

                //               'Modified : ' + dbo.ufnProperDateTimeByColumn(DMM_ProjTransmittal.ModifiedOn) + ' - ' + dbo.ufnGetUserLoginIDByUserID(DMM_ProjTransmittal.ModifiedBy)AS ModifyInfo,
                //                Count(*) OVER() as TotalNoOfRecords ,
                //DMM_ProjTransmittal.IsAutoTransmittalNo as IsAutoTransmittalNo,
                //CASE WHEN IsAutoTransmittalNo = 1 THEN 'Auto'

                //                    ELSE 'Manual' END as IsAutoTransmittalNoToDisplay,
                //DMM_ProjTransmittal.TransmittalDate as TransmittalDateInDateFormat

                ///PMS_DMM_spGetProjTransmittals

                //var query = Repo.AllIncluding(t => t.SignedProject.ProjectClient, t => t.DMM_ProjTransSendingInfo, t => t.DMM_ProjTransReceiptInfo, t => t.DMM_ProjTransNotifyInfo)
                //                ///.Where(t => (t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID) && (t.DeliveryModeID == 1 || t.DeliveryModeID == 2))
                //                .Where(t => t.SignedProject.ProjExecutedCompanyBranchID == vCompanyBranchID && t.IsAutoTransmittalNo == true && t.ProjectID == vProjectID && vDeliveryModeIDs.Contains(t.DeliveryModeID))
                //                .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                //                .Where(t => t.SignedProject.ProjectName.Contains("IGI"))
                //                .OrderBy(t => t.CreatedOn)
                //                .Select(t => new
                //                {
                //                    t.TransmittalID,
                //                    t.TransmittalNo,
                //                    t.TransmittalDate,
                //                    t.SignedProject.ProjectName,
                //                    t.ProjectID,
                //                    t.SignedProject.ProjectClient.ProjClient,
                //                    t.SignedProject.Staff.StaffName,
                //                    t.CreatedOn,
                //                    t.AddressTo,
                //                    t.DeliveryModeID,
                //                    t.DMM_ProjTransDeliveryMode.DeliveryMode
                //                });


            }
        }
    }
}
