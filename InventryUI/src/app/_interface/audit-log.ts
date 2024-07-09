export interface AuditLogDto {
    entityName: string
    action: string
    timestamp: Date
    changes: string
}

  export interface MonthDto {
    month: string;
  }

  export interface DayTotalDto {
    dayDate: string;
    totalAudit: number;
  }
  
  export interface MonthTotalDto {
    month: string;
    dayTotals: DayTotalDto[];
  }


