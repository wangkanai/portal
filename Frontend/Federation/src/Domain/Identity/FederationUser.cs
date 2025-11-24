using Microsoft.AspNetCore.Identity;

namespace Portal.Federation.Identity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class FederationUser : IdentityUser<int> { }