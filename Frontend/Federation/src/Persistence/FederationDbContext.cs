using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Portal.Federation.Identity;

namespace Portal.Federation;

public class FederationDbContext(DbContextOptions<FederationDbContext> options)
   : IdentityDbContext<FederationUser, FederationRole, int>(options) { }