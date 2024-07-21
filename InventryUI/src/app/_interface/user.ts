export interface EmailConfirmationDto {
    email: string;
    clientURI: string;
}
export interface ForgotPasswordDto {
    email: string;
    clientURI: string;
}
export interface RegistrationResponseDto {
    isSuccessfulRegistration: boolean;
    errros: string[];
}

export interface ResetPasswordDto {
    password: string;
    confirmPassword: string;
    email: string;
    token: string;
}

export interface TokenDto {
  isAuthSuccessful: boolean;
  errorMessage: string;
  token: string;
}
export interface UserForAuthenticationDto {
    userName: string;
    password: string;
    clientURI: string;
}

export interface UserForRegistrationDto {
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    roles: string[] |any

}

export interface User {
    email: string;
    firstName: string;
    lastName: string;
    token: string;
}


  export interface UserDetailsDto {
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
  }



  export interface ForgetPasswordResponseDto {
    statusCode: number;
    message: string;
}

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
  }

  export interface UserRoleCreationDto {

    name?: string;
  }

  export interface DefaultPasswordDto {
    password: string;
    confirmPassword: string;
  }