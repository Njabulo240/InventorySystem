export interface Employee {
    id: string;
    firstName: string;
    lastName: string;
    employeeNumber: string;
    position: string;
    email: string;
  }
  
  export interface EmployeeForCreationDto {
    firstName: string;
    lastName: string;
    employeeNumber: string;
    position: string;
    email: string;
  }
  