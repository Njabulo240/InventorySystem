export interface CustomerDto {
    id: string;
    firstName?: string;
    lastName?: string;
    dateOfBirth: Date;
    address?: string;
    country?: string;
    accountCount: string;
    status:boolean;
  }

  export interface CustomerForCreationDto {
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    address: string;
    country: string;
  }

  export interface CustomerForUpdateDto {
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    address: string;
    country: string;
  }

  export interface AccountDto {
    id: string;
    dateCreated: Date;
    accountType?: string;
  }

  export interface AccountForCreationDto {
    accountType?: string;
  }