Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context "../ADMStoreContext" -ContextDir "../ADM.Store.AccessData"


Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context ADMStoreContext -ContextDir "./ADM.Store.AccessData" -Force


Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context ADMStoreContext -ContextDir "./" -Force


if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=admstore;Trusted_Connection=True;");
            }