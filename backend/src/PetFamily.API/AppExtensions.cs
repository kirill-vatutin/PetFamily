﻿using Microsoft.EntityFrameworkCore;
using PetFamily.Infrastructure;

public static class AppExtensions
{
    public async static Task ApplyMigration(this WebApplication app)
    {
        var scope = app.Services.CreateAsyncScope();
        await using var dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbcontext.Database.MigrateAsync();
    }
}