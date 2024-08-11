namespace AIProject;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		string cacheDirectory = FileSystem.CacheDirectory;

		if(!Directory.Exists(cacheDirectory)){
			Directory.CreateDirectory(cacheDirectory);
		}

	}

	private void SendLink(object sender, EventArgs e)
	{
		dressPhoto.Source="";
		GetImageController.GetImage(linkInput.Text);
	}

	private async void OnPickPhotoClicked(object sender, EventArgs e){

		FileResult photo = await MediaPicker.Default.PickPhotoAsync();

		if(photo != null){
			
			string filePath = Path.Combine(FileSystem.CacheDirectory,photo.FileName);
			using Stream sourceStream = await photo.OpenReadAsync();
			using FileStream fileStream = File.OpenWrite(filePath);

			await sourceStream.CopyToAsync(fileStream);

			userPhoto.Source = ImageSource.FromFile(filePath);

		}

	}

	private async void OnTakePhotoClicked(object sender, EventArgs e){
		if(MediaPicker.Default.IsCaptureSupported){
			FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

			if(photo != null){
				string filePath = Path.Combine(FileSystem.CacheDirectory,photo.FileName);

				using Stream sourceStream = await photo.OpenReadAsync();

				using FileStream fileStream = File.OpenWrite(filePath);

				await sourceStream.CopyToAsync(fileStream);

				userPhoto.Source = ImageSource.FromFile(filePath);
			}
		}
	}
}

