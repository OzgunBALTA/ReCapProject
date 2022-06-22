using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult();
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetCarImageById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
        private IResult CheckIfImageLimit(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
