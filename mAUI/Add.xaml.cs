using mAUI.Models;

namespace mAUI;

public partial class Add : ContentPage
{
    string _metod;

    public Add()
    {
        InitializeComponent();
        if (Data.supl == null)
        {
            Data.supl = new Supplier();
            _metod = "POST";
        }
        else
        {
            _metod = "PUT";
            btnAdd.Text = "Редактировать";
            Title = "EditPage";
        }

        tbDeliveries.BindingContext = Data.supl;
    }

    async private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_metod == "POST") PlayerService.Post(Data.supl);
        else PlayerService.Put(Data.supl, Data.supl.SupplierId);
        await Navigation.PopAsync();
    }

    async private void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}