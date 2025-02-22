using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadsService.Migrations
{
    /// <inheritdoc />
    public partial class SeedLeadsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Leads (ContactFirstName, ContactFullName, ContactPhone, ContactEmail, DateCreated, Suburb, Category, Description, Price, Status)
                VALUES 
                ('Alice', 'Alice Johnson', '1234567890', 'alice@example.com', GETDATE(), 'New York', 'Real Estate', 'Lead for property sale', 750.00, 'New'),
                ('Joana', 'Joana Trees', '4232456655', 'joana@example.com', GETDATE(), 'California', 'Technology', 'Lead for technology sale', 250.00, 'New'),
                ('Bob', 'Bob Smith', '9876543210', 'bob@example.com', GETDATE(), 'Los Angeles', 'Finance', 'Lead for loan application', 300.00, 'Accepted'),
                ('Charlie', 'Charlie Brown', '5551234567', 'charlie@example.com', GETDATE(), 'Chicago', 'Technology', 'Lead for software development', 1200.00, 'Declined')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Leads WHERE ContactEmail IN ('alice@example.com', 'bob@example.com', 'charlie@example.com')");
        }
    }
}
