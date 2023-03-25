using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace POSBill.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "security_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "longtext", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    sections = table.Column<string>(type: "longtext", nullable: false),
                    areas = table.Column<string>(type: "longtext", nullable: false),
                    inactive = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_security_roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stock_master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    stock_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    tax_type_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    long_description = table.Column<int>(type: "int", nullable: false),
                    units = table.Column<string>(type: "longtext", nullable: false),
                    mb_flag = table.Column<string>(type: "longtext", nullable: false),
                    sales_account = table.Column<string>(type: "longtext", nullable: false),
                    cogs_account = table.Column<string>(type: "longtext", nullable: false),
                    inventory_account = table.Column<string>(type: "longtext", nullable: false),
                    adjustment_account = table.Column<string>(type: "longtext", nullable: false),
                    wip_account = table.Column<string>(type: "longtext", nullable: false),
                    dimension_id = table.Column<int>(type: "int", nullable: false),
                    dimension2_id = table.Column<int>(type: "int", nullable: false),
                    purchase_cost = table.Column<double>(type: "double", nullable: false),
                    material_cost = table.Column<double>(type: "double", nullable: false),
                    labour_cost = table.Column<double>(type: "double", nullable: false),
                    overhead_cost = table.Column<double>(type: "double", nullable: false),
                    inactive = table.Column<int>(type: "int", nullable: false),
                    no_sale = table.Column<int>(type: "int", nullable: false),
                    no_purchase = table.Column<int>(type: "int", nullable: false),
                    editable = table.Column<int>(type: "int", nullable: false),
                    depreciation_method = table.Column<string>(type: "longtext", nullable: false),
                    depreciation_rate = table.Column<double>(type: "double", nullable: false),
                    depreciation_factor = table.Column<double>(type: "double", nullable: false),
                    depreciation_start = table.Column<DateOnly>(type: "date", nullable: false),
                    depreciation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    fa_class_id = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_master", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    real_name = table.Column<string>(type: "longtext", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    language = table.Column<string>(type: "longtext", nullable: false),
                    date_format = table.Column<int>(type: "int", nullable: false),
                    date_sep = table.Column<int>(type: "int", nullable: false),
                    tho_sep = table.Column<int>(type: "int", nullable: false),
                    dec_sep = table.Column<int>(type: "int", nullable: false),
                    theme = table.Column<string>(type: "longtext", nullable: false),
                    page_size = table.Column<string>(type: "longtext", nullable: false),
                    prices_dec = table.Column<int>(type: "int", nullable: false),
                    qty_dec = table.Column<int>(type: "int", nullable: false),
                    rates_dec = table.Column<int>(type: "int", nullable: false),
                    percent_dec = table.Column<int>(type: "int", nullable: false),
                    show_gl = table.Column<int>(type: "int", nullable: false),
                    show_codes = table.Column<int>(type: "int", nullable: false),
                    show_hints = table.Column<int>(type: "int", nullable: false),
                    last_visit_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    query_size = table.Column<int>(type: "int", nullable: false),
                    graphic_links = table.Column<int>(type: "int", nullable: false),
                    pos = table.Column<int>(type: "int", nullable: false),
                    print_profile = table.Column<int>(type: "int", nullable: false),
                    rep_popup = table.Column<int>(type: "int", nullable: false),
                    sticky_doc_date = table.Column<int>(type: "int", nullable: false),
                    startup_tab = table.Column<string>(type: "longtext", nullable: false),
                    transaction_days = table.Column<int>(type: "int", nullable: false),
                    save_report_selections = table.Column<int>(type: "int", nullable: false),
                    use_date_picker = table.Column<int>(type: "int", nullable: false),
                    def_print_destination = table.Column<int>(type: "int", nullable: false),
                    def_print_orientation = table.Column<int>(type: "int", nullable: false),
                    inactive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "security_roles");

            migrationBuilder.DropTable(
                name: "stock_master");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
