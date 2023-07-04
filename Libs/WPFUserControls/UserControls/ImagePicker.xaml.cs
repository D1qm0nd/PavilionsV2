using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using WPFUserControls.Handlers;

namespace WPFUserControls.UserControls;

public partial class ImagePicker : Border, INotifyPropertyChanged
{
    public ImagePicker()
    {
        InitializeComponent();
        PropertyChanged += (obj, args) => SetBackgroundImage();
    }

    public bool isEnabledToChange { get; set; } = true;
    
    private byte[]? buffer = default;

    public byte[]? Buffer
    {
        get => buffer;
        set //private 
        {
            buffer = value;
            OnPropertyChanged(nameof(Buffer));
        }
    }

    private void ImagePicker_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (isEnabledToChange == false) 
            return;
        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = "|*| |*.png| |*jpeg| |*jpg";
        fileDialog.ShowDialog();
        try
        {
            PickImageToBuffer(fileDialog.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void PickImageToBuffer(string path)
    {
        Buffer = ImageHandler.GetImageBytes(path);
    }

    public void SetImageToBuffer(byte[] imageBytes)
    {
        try
        {
            Buffer = imageBytes;
        }
        catch (Exception e)
        {
            throw new ArgumentException(nameof(imageBytes));
        }
    }

    private void SetBackgroundImage()
    {
        try
        {
            var source = ImageHandler.BytesToBitmapImage(Buffer);
            this.Background = new ImageBrush()
            {
                ImageSource = source
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(nameof(Buffer));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ImagePicker_OnMouseEnter(object sender, MouseEventArgs e)
    {
        this.Opacity = 0.9;
    }

    private void ImagePicker_OnMouseLeave(object sender, MouseEventArgs e)
    {
        this.Opacity = 1;
    }
}