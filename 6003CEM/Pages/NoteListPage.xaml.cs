using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6003CEM.Pages;

public partial class NoteListPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editId;

    public NoteListPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async() => listView.ItemsSource = await _dbService.GetList());
    }

    private async void saveButton_Clicked(object? sender, EventArgs e)
    {
        var list = BindingContext as List; // Get the binding context

        if (_editId == 0)
        {
            await _dbService.Create(list);
        }
        else
        {
            list.Id = _editId;
            await _dbService.Update(list);
            _editId = 0;
        }

        // Reset the binding context
        BindingContext = new List();
        listView.ItemsSource = await _dbService.GetList();
    }

    private async void listView_ItemTapped(object? sender, ItemTappedEventArgs e)
    {
        var list = (List)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                _editId = list.Id;
                BindingContext = list; // Set the binding context to the selected item
                break;
            case "Delete":
                await _dbService.Delete(list);
                listView.ItemsSource = await _dbService.GetList();
                break;
        }
    }
}