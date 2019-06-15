﻿<? xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns = "http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Notes.NoteEntryPage"
             Title="Note Entry">
    <StackLayout Margin = "20" >
        < Editor Placeholder="Enter your note"
                Text="{Binding Text}"
                HeightRequest="100" />
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width = "*" />
                < ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <Button Text = "Save"
                    Clicked="OnSaveButtonClicked" />
            <Button Grid.Column="1"
                    Text= "Delete"
                    Clicked= "OnDeleteButtonClicked" />
        </ Grid >
    </ StackLayout >
</ ContentPage >