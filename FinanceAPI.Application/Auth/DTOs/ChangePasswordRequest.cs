﻿namespace FinanceAPI.Application.Auth.DTOs;
public record ChangePasswordRequest(string CurrentPassword, string NewPassword, string ConfirmPassword);