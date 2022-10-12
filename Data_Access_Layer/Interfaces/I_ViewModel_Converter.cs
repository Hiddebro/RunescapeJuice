namespace Data_Access_Layer.Interfaces
{
    public interface I_ViewModel_Converter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewmodel);

    }

}
