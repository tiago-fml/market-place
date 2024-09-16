using catalog_service.Data;

namespace catalog_service.Repositories;

public class UnityOfWork : IUnityOfWork
{
    private ApplicationDbContext Context { get; set; }
    public IProductRepository ProductRepo { get; set; }

    public UnityOfWork(ApplicationDbContext context, IProductRepository productRepo)
    {
        Context = context;
        ProductRepo = productRepo;
    }
    
    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}