namespace Data_Access_Layer.Interfaces
{
    public interface IViewModel_Converter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewmodel);

    }

}
