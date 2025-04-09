namespace FinanceAPI.Application.Auth.DTOs;
public record ChangePasswordRequestDto(string CurrentPassword, string NewPassword, string ConfirmPassword);