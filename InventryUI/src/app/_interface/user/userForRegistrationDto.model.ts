export interface UserRoleDto {
    id?: string;
    name?: string;
    dateCreated: Date;
  }

  export interface UserDto {
    id?: string;
    userName?: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    emailConfirmed?: string;
    roles?: string[];
  }

  export interface UserForRegistrationDto {
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
}

export interface UserForUpdateDto {
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  roles: string[] |any

}
