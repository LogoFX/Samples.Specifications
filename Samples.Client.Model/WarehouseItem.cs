using System;
using JetBrains.Annotations;
using Samples.Client.Model.Contracts;
using Samples.Client.Model.Shared.Validation;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    internal sealed class WarehouseItem : AppModel, IWarehouseItem
    {
        public WarehouseItem(
            string kind, 
            double price, 
            int quantity)
        {
            Id = Guid.NewGuid();
            _kind = kind;
            _price = price;
            _quantity = quantity;            
        }

        private string _kind;

        [StringValidation(IsNulOrEmptyAllowed = false, MaxLength = 63)]
        public string Kind
        {
            get => _kind;
            set => SetProperty(ref _kind, value);
        }

        private double _price;

        [DoublePositiveValidation(ErrorMessage = "Price must be positive.")]
        public double Price
        {
            get => _price;
            set
            {
                SetProperty(ref _price, value);
                NotifyOfPropertyChange(() => TotalCost);
            }
        }

        private int _quantity;

        [NumberValidation(Minimum = 1, ErrorMessage = "Quantity must be positive.")]
        public int Quantity
        {
            get => _quantity;
            set
            {                
                SetProperty(ref _quantity, value);
                NotifyOfPropertyChange(() => TotalCost);
            }
        }        

        public double TotalCost => _quantity*_price;
    }
}
