
export enum eModule {
  None = 0,

  // Reports & Dashboard
  KPIs = 1000,
  KPIs_Dashboard,
  KPIs_Reports,

  // Human Resources
  HR = 1100,
  HR_Dashboard,
  HR_Departments,
  HR_Positions,
  HR_Employees,
  HR_Availabilities,
  HR_Schedules,
  HR_Leaves,
  HR_Attendance,
  HR_PayPeriods,
  HR_Payroll,
  HR_Recruitment,

  // Inventory & Logistics
  Inventory = 1200,
  Inventory_Brands,
  Inventory_Categories,
  Inventory_Products,
  Inventory_StockMoves,
  Inventory_LowStock,

  Logistics = 1250,
  Logistics_Shipments,
  Logistics_Tracking,

  // Purchases
  Purchases = 1300,
  Purchases_Vendors,
  Purchases_Orders,
  Purchases_Bills,

  // Sales & CRM
  Sales = 1400,
  Sales_Dashboard,
  Sales_Customers,
  Sales_Estimates,
  Sales_Quotations,
  Sales_Invoices,
  Sales_POS,

  CRM = 1450,
  CRM_Pipeline,
  CRM_Activities,

  // Projects
  Projects = 1500,
  Projects_Dashboard,
  Projects_Expenses,
  Projects_Projects,
  Projects_Tasks,
  Projects_Timesheets,

  // Booking / Scheduling
  Booking = 1600,
  Booking_Services,
  Booking_Resources,
  Booking_Appointments,

  // Assets & Maintenance
  Equipment = 1700,
  Equipment_Equipments,
  Equipment_Rentals,
  Equipment_Requests,

  // Budget & Expenses
  Global_Budget = 1710,
  Expenses,
  Department_Budget,
  Location_Budget,
  Other_Budget,

  // Rental
  Rental = 1750,
  Rental_Equipment,
  Rental_Orders,

  // Manufacturing
  Manufacturing = 1800,
  Manufacturing_Orders,
  Manufacturing_BOM,
  Manufacturing_WorkOrders,

  QualityControl = 1850,

  // Accounting & Finance
  Finance = 1900,
  Finance_Dashboard,
  Finance_Budget,
  Finance_Reports,
  Finance_ClientStatements,
  Finance_PaymentsReceived,
  Finance_PaymentsSent,

  Accounting = 1950,
  Accounting_Dashboard,
  Accounting_FiscalYear,
  Accounting_Accounts,
  Accounting_Journal,
  Accounting_MonthlyJournal,
  Accounting_Entries,
  Accounting_Taxes,
  Accounting_Reconciliation,

  // Communication & Collaboration
  Communication = 2000,
  Communication_Email,
  Communication_Chat,
  Communication_WhatsApp,
  Communication_SMS,

  // Settings & Security
  Settings = 2100,
  Settings_Company,
  Settings_Accounting,
  Settings_HR,
  Settings_Financial,
  Settings_Users,
  Settings_Roles,
  Settings_Taxes,
  Settings_Locations,
  Settings_Notifications,
  Settings_System,
  Settings_WebApi,

  // Subscription / Billing
  Subscription = 2200,
  Subscription_Subscriptions,
  Subscription_Billing,
  Subscription_Invoices,
  Subscription_Payments
}
export interface LocalDbEntity {
  id?: number;
  createdAt?: string;
  updatedAt?: string;
}



export interface LocalizedValue {
  en?: string;
  fr?: string;
}