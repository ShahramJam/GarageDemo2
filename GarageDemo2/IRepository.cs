namespace GarageDemo2;

public interface IRepository
{
    Garage? Load();

    void Save(Garage garage);
}
