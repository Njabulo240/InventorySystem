export interface ResetPasswordDto {
    password: string;
    confirmPassword: string;
    email: string;
    token: string;
}

export interface ChangePasswordDto {
    previousPassword: string;
    password: string;
    confirmPassword: string;
    email: string;
  }

  export interface DefaultPasswordDto {
    password: string;
    confirmPassword: string;
  }