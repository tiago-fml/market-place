namespace catalog_service.Repositories;

public interface IUnityOfWork
{
    IProductRepository ProductRepo { get; set; }

    Task SaveChangesAsync();
}