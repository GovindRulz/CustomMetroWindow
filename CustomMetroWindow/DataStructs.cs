using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace CustomMetroWindow
{
    public static class DataStructs
    {
        public struct ConnectionParameters
        {
            public string ServerName;
            public string DbName;
            public string UserName;
            public string Password;
        }
        public struct CompanyConf
        {
            public bool WINDOWSPRINT;
            public bool HALFPAGEPRINTING;
            public bool PRINTPREVIEW;
            public bool AllowMinusStock;
            public bool TSPLBarcodePrinting;
            public bool INPUTSCHEMEPERINBILLING;
            public bool INPUTSCHEMEAMTINBILLING;
            public bool INPUTDISCPERINBILLING;
            public bool INPUTDISCAMTINBILLING;
            public bool INPUTMRPINBILLING;
            public bool INPUTUNITINBILLING;
            public bool INPUTFREEINBILLING;
            public bool INPUTREPLACEMENTINBILLING;
            public bool LANDINGCOSTEXCLUSIVEOFDISCOUNTS;
            public bool LANDINGCOSTEXCLUSIVEOFTAX;
            public bool UNIFLEXMOBILESYNC;
            public bool FIELDMAXMOBILESYNC;
            public bool CONTINOUSPRINTINGDOSMODE;
            public bool ROUTEWISEBILLING;
            public bool COMPUTESELLINGRATEONSALESMARGIN;
            public bool COMPUTETAXABLERATEFROMMRP;
            public bool DISABLEFUZZYSEARCH;
            public bool DISPLAYDISCRIPTIONINSTOCKREPORTS;
        }
        public struct UserSplRights
        {
            public bool DisplayCostingInSales;
            public bool OverRideCreditCheckInSales;
            public bool OverRideCostCheckInSales;
            public bool OverRideStockCheckInSales;
            public bool AlterAuditedTransactionsInPurchase;
            public bool AlterAuditedTransactionsInCreditNote;
            public bool AlterAuditedTransactionsInDebitNote;
            public bool AlterAuditedTransactionsInReciept;
            public bool AlterAuditedTransactionsInPayment;
            public bool AlterAuditedTransactionsInManufactureing;
            public bool AlterAuditedTransactionsInStockJournal;
            public bool AlterAuditedTransactionsInJournal;
            public bool DisableRateEditingInSales;
        }

        public struct PrnBill
        {
            public string MSeries;
            public int MVno;
            public string MBillDate;
            public string MCustname;
            public string MAdd1;
            public string MAdd2;
            public string MAdd3;
            public string MPhone;
            public string MMobile;
            public string MTin;
            public string MDrugLicNo;
            public string MFoodLicNo;
            public string MCstNo;
            public string MPanNo;
            public string MPoNo;
            public string MPoDate;
            public string MItemTotal;
            public string MTaxTotal;
            public string MDiscountTotal;
            public string MSchemeTotal;
            public string MGrandTotal;
            public string MTaxableAmt;
            public string MRoundOFF;
            public string MDelThrough;
            public string MDestination;
            public string MDelNoteNo;
            public string MFormType;
            public bool MIsCash;
            public bool MIsVatOnMrp;
            public double MCessTotal;
            public double MNetweight;
            public double MServiceTotal;
            public double MServiceDiscounts;
            public double MServiceTaxAmount;
            public double MCessOnST;
            public double MServiceNetAmount;
            public double MItemNetAmount;
            public double MNetTotal;
            public string AmountInWords;
            public string CreditCardHolderName;
            public string Narration;
            public string ChqNo;
            public string SalesmanName;
            public string DiscNarr;
            public string MBillType;

            public string MPurchaseOrderNumber;
            public string MPurchaseOrderDate;
            public string MDispatchThrough;
            public string MVehicleNumber;
            public string MDriverName;
            public string MDeliveryNoteNumber;
            public string MGatePassNumber;
            public double MBillCashDiscPer;
            
        }
        public struct UserInfo
        {
            public int Id;
            public string UserName;
            public string PassWord;
            public bool IsAdministrator;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct CurrentUser
        {
            public string UserName;
            public string MachineName;
            public int UserId;
            public bool IsAdmin;
            public bool IsTech;
        }
        //-------------------------------------//
        public struct MasterData
        {
            public string TableName;
            public int Id;
            public string Code;
            public string SaveMode;
            public string Name;
            public string ListName;
            public bool IsActive;
            public int Userid;

        }
       
        public struct EmployeeMast
        {
            public string SaveMode;
            public int Id;
            public string EmpCode;
            public string EmpName;
            public string EmpRFId;
            public string DateofBirth;
            public string EmpAddress1;
            public string EmpAddress2;
            public string EmpPlace;
            public string EmpDistrict;
            public string EmpState;
            public string EmpPin;
            public string EmpPhone;
            public string EmpMobile;
            public string OfficeEmail;
            public string PersonalEmail;
            public string BloodGroup;
            public string PanNumber;
            public int DesigId;
            public int WorkId;
            public int DepId;
            public int ShiftId;
            public string DateofJoining;
            public int PayScaleId;
            public int LocationId;
            public string EmpQualification;
            public string EmpExperiance;
            public string EmpAppraisal;
            public bool EmpStatus;
            public string ListName;
            public int UserId;
            public int GroupId;
            public string BankName;
            public string BranchName;
            public string AccountNumber;
            public string IFSCcode;
            public decimal AnnualCTC;

        }

        public struct EmployeeDesignation
        {
            public int DesigId;
            public int DesigCode;
            public string DesigName;
            public string ListName;
            public bool IsActive;
        }
        public struct EmployeeShift
        {
            public string SaveMode;
            public int id;
            public string ShiftCode;
            public string Description;
            public string ShiftStart;
            public string ShiftEnd;
            public string Exceptions;
            public int MaxException;
            public string EvngExceptions;
            public int EvngMaxException;
            public string Remarks;
            public string ListName;
            public bool IsActive;
            public int UserId;
        }

        public struct EmployeeWork
        {
            public int workId;
            public int WorkCode;
            public string WorkDescription;
            public string ListName;
            public bool IsActive;
        }
        public struct WorkGrade
        {
            public int GradeId;
            public int GradeCode;
            public string GradeName;
            public string ListName;
            public bool IsActive;
        }
        public struct LeaveType
        {
            public int LeaveId;
            public int LeaveCode;
            public string Leavetype;
            public bool IsPaid;
            public string ListName;
            public bool IsCarryForward;
            public bool IsActive;
        }
       
        public struct OfficeLocation
        {
            public string SaveMode;
            public int Id;
            public string LocationCode;
            public string LocationName;
            public string LocationDistrict;
            public string LocationState;
            public string LocationContry;
            public string ListName;
            public bool IsActive;
            public int UserId;
        }

        public struct Payhead
        {
            public string SaveMode;
            public int id;
            public string PayheadCode;
            public string PayheadName;
            public int PayheadType;
            public bool IsAfftectNetsalary;
            public string AccountHead;
            public string PayheadHashstring;
            public string ListName;
            public bool IsActive;
            public int UserId;
            public bool IsLOPAffect;
        }

        
        public struct PayHeadType
        {
            public int PayHeadTypeId;
            public int PayHeadTypeCode;
            public string Payheadtype;
            public string ListName;
            public bool IsActive;
         }
        public struct Project
        {
            public string SaveMode;
            public int Id;
            public string ProjectCode;
            public string ProjectName;
            public string ProjectDescription;
            public string ProjectDuration;
            public string ProjectStatus;
            public string ListName;
            public bool IsActive;
            public int Userid;
        }

        public struct TaskDefinition
        {
            public string SaveMode;
            public int Id;
            public string TaskCode;
            public string TaskName;
            public string TaskDescription;
            public string ListName;
            public bool IsActive;
            public int UserId;
        }

       public struct EmployeeLeave
       {
           public string SaveMode;
           public int Id;
           public string LeaveCode;
           public string LeaveType;
           public bool IsPaid;
           public string ListName;
           public bool IsCarryforward;
           public bool IsActive;
           public int UserId;
       }

      
       public struct SaveEmpResignation
       {
           public int ResigId;
           public int EmpId;
           public DateTime LetterDate;
           public string Reason;
           public string NoticePeroid;
           public DateTime RelivingDate;
           public string RecommendedBy;
           public string ApprovedBy;
           public bool IsActive;
       }
       public struct SaveLeaveApproval
       {
           public int EmpId;
           public int LeaveRequestId;
           public DateTime sanctionedDate;
           public bool IsSanctioned;
           public string RejectReason;
           public string ApprovedBy;
           public bool IsActive;
       }

       public struct SaveLeavePolicy
       {
           public int EmpId;
           public int LeaveId;
           public int MaxLeavePerYear;
           public double AvailLeave;
           public double MaxLeaveTogether;
           public double LeaveTaken;
           public double LeaveBalance;
           public bool IsActive;
       }
       public struct SaveLeaveRequest
       {
           public int LeaveRequestId;
           public int EmpId;
           public int LeaveId;
           public DateTime RequestDate;
           public DateTime LeaveFrom;
           public DateTime LeaveTo;
           public double NumberofDays;
           public string Reason;
           public string LeaveStatus;
           public bool IsActive;
       }
       public struct SavePayScale
       {
           public int PayscaleId;
           public string PayscaleName;
           public string PayscaleShortname;
           public string PayscaleFormula;
           public string ApprovedBy;
           public string ListName;
           public DateTime EffectiveFrom;
           public DateTime EffectiveTo;
           public bool IsActive;
       }
       public struct SavePayscaleDetails
       {
           public int PayheadId;
           public string PayheadConfiguration;
           public string ListNmae;

       }
       public struct SaveTaskAllocation
       {
           public int TaskAllocationId;
           public int EmpId;
           public int ProjectId;
           public int TaskId;
           public DateTime StartingDate;
           public DateTime EndingDate;
           public string TaskStatus;
           public bool IsActive;
       }
       public struct SaveTaskRemunaration
       {
           public int ProjectId;
           public int TaskId;
           public int GradeId;
           public int Value;
           public string ApprovedBy;
           public bool Isactive;
       }
       public struct Holiday
       {
           public int Id;
           public string HolidayDate;
           public string HolidayName;
           public int LoctionId;
           public bool IsActive;
           public string Savemode;
           public int UserId;
       }


        //-------------------------------------//
        public struct Unit
        {
            public int Id;
            public string Code;
            public string Name;
            public string ListName;
            public bool AllowDecimal;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct Scheme
        {
            public long SchemeId;
            public string SchemeName;
            public DateTime SchemeBeginDate;
            public DateTime SchemeEndDate;
            public bool IsActive;
            public int UserId;
            public string MachineName;
            public string SaveMode;
        }
        public struct Company
        {
            public int Id;
            public string CompanyName;
            public string FirmName;
            public string DoorNo;
            public string Street;
            public string City;
            public string District;
            public string State;
            public string Country;
            public string PinCode;
            public string Phone1;
            public string Phone2;
            public string Phone3;
            public string Fax;
            public string Email;
            public string WebSite;
            public string Tin;
            public string Cst;
            public string FoodLic;
            public string DrugLic;
            public string ExciseRegNo;
            public string DBname;
            public string TallySyncName;
            public DateTime FinYearBegining;
            public DateTime BooksFromDate;
            public string FinYrCd;
            public string CurrentDatabaseVersion;
            public string CurrentExecutableVersion;
            public string LastUpdateDate;
            public string FldMaxlicencekey;
            public string FldMaxcustomerIdentification;
            public string FldMaxwebserviceAddress;
            public string FldMaxDistributorName;
            public string ListName;
            public string SaveMode;
        }

        public struct BillingScrTempValues
        {
            public string Series;
            public DateTime EntryDate;
            public DateTime SrchFromDate;
            public DateTime SrchToDate;
            public string SalesMan;
            public int SalesManId;
            public string DeliveryMan;
            public int DeliveryManId;
            public string Route;
            public int RouteId;
            public string Godown;
            public int GodownId;
            public bool IsCash;
        }
        public struct RcptScrTempValues
        {
            public string Series;
            public DateTime EntryDate;
            public DateTime SrchFromDate;
            public DateTime SrchToDate;
            public string SalesMan;
            public int SalesManId;
            public bool IsCash;
            public bool IsAutoRef;
        }

        public struct SoftwareInfo
        {
            public string ServerName;
            public string BackupPath;
            public string LogoPath;
            public string DBName;
            public string AppPath;
            public string Pos;
            public int HalfPageLineCount;
            public int FullPageLineCount;
        }
        public struct SimpleEntityStruct
        {
            public int Id;
            public string Code;
            public string Name;
            public string ListName;
            public string TableName;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct EntityWithParentStruct
        {
            public int Id;
            public string Code;
            public string Name;
            public int ParentId;
            public string ParentName;
            public string ListName;
            public string TableName;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }


        public struct SaveSeries
        {
            public string Series;
            public int TrnCode;
            public bool IsActive;
            public bool IsManual;
            public string FormType;
            public int StartingNo;
            public string Declaration;
            public string BillTemplateFile;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }

        public struct Ledger
        {
            public int ledgerId;
            public string LedgerCode;
            public string LedgerName;
            public int AccountHeadId;
            public string ListName;
            public string DrOrCr;
            public double Amount;
            public int FinYear;
            public DateTime trndate;
            public bool ShowInTransactionVouchers;
            public bool ShowInPurchaseVch;
            public bool ShowInSalesVch;
            public bool ShowInCreditNoteVch;
            public bool ShowInDebitNoteVch;
            public bool IsSurcharge;
            public int SurchargeParentLedger;
            public double SurchargePercent;
            public string SaveMode;
            public int UserId;
            public string MachineName;
            
        }

        public struct PriceListMaster
        {
            public int PriceListId;
            public string  PriceListCode;
            public string PriceListName;
            public double IncDcrPercent;
            public bool IsIncr;
            public bool FixedPriceList;
            public bool IsActive;
            public double DiscountPercent;
            public double DiscountAmount;
            public string ListName;
            public string SaveMode;

            public int UserId;
            public string MachineName;
        }

        public struct ServiceMaster
        {
            public int ServiceId;
            public string ServiceCode;
            public string ServiceName;
            public int TaxConfId;
            public string Discription;
            public string ListName;
            public int ServiceGrpID;
            public int ServiceCatId;
            public string ShortName;
            public string PrintName;
            public string ThirdPartyName;
            public double Rate;
            public bool IsRateInclTax;
            public bool IsActive;
            public bool IsBlocked;
            public string SaveMode;

            public int UserId;
            public string MachineName;
        }

        public struct itemStruct
        {
            public int ItemId;
            public string Itemcode;
            public string ItemName;
            public string ShortName;
            public string PrintName;
            public string ThirdPartyName;
            public string ListName;
            public string Discription;
            public int ItemCatId;
            public int ItemGroupId;
            public int TaxGrpId;
            public int TaxConfId;
            public int UnitId;
            public double NetWeight;
            public double Mrp;
            public double SalesMargin;
            public double MarginOnMrp;
            public double MinOrderQty;
            public int OuterPerCase;
            public int NosPerOuter;
            public bool IsDrug;
            public bool IsActive;
            public bool IsBlocked;
            public bool IsRawMaterial;
            public bool MrpTax;
            public bool MrpIncTax;
            public bool MaintainBatch;
            public bool MaintainPartNo;
            public bool IsSemiProcessed;
            public bool IsFxdPriceList;
            public bool IsService;
            public string ItemCatName;
            public string ItemGroupName;
            public string TaxGrpName;
            public string TaxConfName;
            public string UnitName;

            public string SaveMode;

            public int UserId;
            public string MachineName;
        }
        public struct LedgerStruct
        {
            public int ledgerId;
            public string LedgerCode;
            public string LedgerName;
            public string LedgerShortName;
            public string LedgerThirdPartyName;
            public int AccountHeadId;
            public string Add1;
            public string Add2;
            public string Add3;
            public string Add4;
            public string LandMark;
            public string PinCode;
            public string ContPerson;
            public string Mobile;
            public string Phone;
            public string EmailId;
            public string TinNo;
            public string FoodLicNo;
            public string DrugLicNo;
            public string CstNo;
            public string PanNo;
            public int CustCatID;
            public int CustGroupID;
            public int AreaId;
            public int RouteID;
            public int EmplCatId;
            public double BillWiseCreditLimit;
            public int BillWiseCreditDays;
            public double OverallCreditLimit;
            public int MaxNoOfPendingBills;
            public bool SeriesWiseBlocking;
            public bool IsActive;
            public bool IsInterState;
            public bool IsSpecial;
            public bool IsVatOnMrp;
            public bool IsForm45;
            public bool IsTaxExempted;
            //public string BillSeries;
            public string ListName;
            
            public bool IsCustomer;
            public bool IsSupplier;
            public bool IsEmployee;
            public bool IsBranch;
            public string CustCatName;
            public string CustGroupName;
            public string AreaName;
            public string RouteName;
            public string EmplCatName;

            public string PartyBankName;
            public string PartyBankIFSC;
            public string PartyBankAccNo;
            public string SalesBillSeries;
            public string PurchaseBillSeries;


            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SavePurchase
        {
            public int PurchaseId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public DateTime InvDate;
            public string SupInvNo;
            public int LedgerId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double PurchaseAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SavePurchaseOrder
        {
            public int PurchaseId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public DateTime InvDate;
            public string SupInvNo;
            public int LedgerId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double PurchaseAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SaveLoadingSheet
        {
            public int LoadingSheetId;
            public int DelManId;
            public DateTime LoadingDate;
            public string LoadingSheetName;
            public string SaveMode;
            public int UserId;
            public string MachineName;

        }
        public struct SaveSales
        {
            public int SalesId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public int LedgerId;
            public int SalesmanId;
            public int DeliverymanId;
            public int PriceListId;
            public bool UseAdditionalInfoOnBill;
            public int BillingAddressId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double SalesAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public double CashRecived;
            public double BalancePaid;
            public string CreditCardHolderName;
            public string CreditCardNumber;
            public long PrivilageCardCode;

            public string PurchaseOrderNumber;
            public DateTime PurchaseOrderDate;
            public string DispatchThrough;
            public string VehicleNumber;
            public string DriverName;
            public string DeliveryNoteNumber;
            public string GatePassNumber;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public bool IsCash;
            public double BillCashDiscPer;
            public string SaveMode;
            public int UserId;
            public string MachineName;
            

        }
        public struct SaveSalesOrder
        {
            public int SalesOrderId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public int LedgerId;
            public int SalesmanId;
            public int DeliverymanId;
            public int PriceListId;
            public int UseAdditionalInfoOnBill;
            public int BillingAddressId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double SalesAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SaveCreditNote
        {
            public int CreditNoteId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public int LedgerId;
            public int SalesmanId;
            public int DeliverymanId;
            public int UseAdditionalInfoOnBill;
            public int BillingAddressId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double CreditNoteAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SaveDebitNote
        {
            public int DebitNoteId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime BillDate;
            public int LedgerId;
            public int SalesmanId;
            public int DeliverymanId;
            public int UseAdditionalInfoOnBill;
            public int BillingAddressId;
            public int GodownId;
            public string AgnstSeries;
            public int AgnstVno;
            public int AgnstFinYear;
            public double ItemTotal;
            public double TaxAbleAmt;
            public double DebitNoteAccountVal;
            public double TaxTotal;
            public double LineDiscountTotalAmt;
            public double LineSchemeTotalAmt;
            public double DiscAftTaxAmt;
            public double GrandTotal;
            public double RoundOff;
            public bool IsVatOnMrp;
            public string Narration;
            public bool AutoRoundOff;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SaveReciept
        {
            public Int32 RecieptId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime RecptDate;
            public int LedgerId;
            public double RecAmt;
            public bool IsCash;
            public string Narration;
            public DateTime ChqDate;
            public string ChqNo;
            public int EmplId;
            public bool IsOnAcc;
            public int Bank;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SavePayment
        {
            public Int32 PaymentId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime RecptDate;
            public int LedgerId;
            public double RecAmt;
            public bool IsCash;
            public string Narration;
            public DateTime ChqDate;
            public string ChqNo;
            public int EmplId;
            public bool IsOnAcc;
            public int Bank;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct SaveStockJournal
        {
            public Int32 StkJournalId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime TransactionDate;
            public int SourceGodown;
            public int DestinationGodown;
            public int PhysicalStkAdjId;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }

        public struct SaveJournal
        {
            public Int32 JournalId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime TrnDate;
            public int LedgerId;
            public double DebitAmount;
            public double CreditAmount;
            public string Narration;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }

        public struct SaveManufacturingVch
        {
            public Int32 ManufacturingVchId;
            public string Series;
            public int Vno;
            public int FinYear;
            public DateTime TransactionDate;
            public int SourceGodown;
            public int DestinationGodown;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }

        public struct SaveMobileOrderProfile
        {
            public int Id;
            public string ProfileName;
            public string Licensekey;
            public string CustomerIdentification;
            public string WebServiceUrl;
            public string DistributionName;
            public string LoginName;
            public string LoginPassword;
            public string SaveMode;
            public DateTime LastSyncDate;
            public int UserId;
            public string MachineName;
        }

        public struct ProductComposition
        {
            public Int32 ProductCompositionId;
            public Int32 ItemId;
            public double Quantity;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct BillingAddress
        {
            public Int32 Id;
            public string BillName;
            public string BillAdd1;
            public string BillAdd2;
            public string BillAdd3;
            public string BillAdd4;
            public string BillPh;
            public string SaveMode;
            public int UserId;
            public string MachineName;
        }
        public struct LedgerInfoSalesVoucher
        {
            public string LedgerName;
            public string Address;
            public string Tin;
            public double BillWiseCreditLimit;
            public int BillWiseCreditDays;
            public double OverallCreditLimit;
            public int MaxNoOfPendingBills;
            public bool SeriesWiseBlocking;
            public double BalAmt;
            public int PriceListId;
            public string PriceListName;
            public int PendingBillCount;
            public int PendingBillDayCount;
            public double BillAmt;
            public string SalesBillSeries;
            public string PurchaseBillSeries;
        }
       
        public struct ReportProperties
        {
            public string ReportName;
            public DateTime RptFromDate;
            public DateTime RptToDate;
            public string ReportTemplateName;
            public string ReportAdditionalInfo;
        }

        public struct LeaveRequest
        {
              public int  UserId;
              public int Id;
			  public int LeaveTypeId;
			  public string LeaveFromDate;	
			  public string LeaveToDate;
              public bool LeaveFromHalfDay;
              public bool LeaveFromFullDay;
              public bool LeaveToHalfDay;
              public bool LeaveToFullDay;
			  public double NumberofDays;
		      public string	Reason;	
			  public  bool	IsActive;
              public string SaveMode;
        }

        public struct PayScaleType
        {
            public string Formula;
            public string HashString;
        }

        public struct PreviousTds
        {
            public string SaveMode;
            public int Empid;
            public double GrossSalary;
            public double TdsPaid;
            public string FromDate;
            public string Todate;
            public bool IsProof;
            public int UserId;

        }

        public struct UserGroup
        {
            public string SaveMode;
            public int Id;
            public string GroupName;
            public bool IsAdministrator;
            public bool IsTechSupport;
            public bool IsActive;
            public int UserId;
        }
    }
    public struct AttUpdate
    {

        public string FromDate;
        public string ToDate;
        public string LocationName;

    }
    public class CustomErrorDetail
    {
        public string ErrorInfo { get;set; }
        public string ErrorDetails { get;set; }
    }
}

