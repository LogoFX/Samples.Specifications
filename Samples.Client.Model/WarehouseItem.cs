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
            Kind = kind;
            Price = price;
            Quantity = quantity;
            
            CommitChanges();           
        }

        private string _kind;

        [StringValidation(IsNulOrEmptyAllowed = false, MaxLength = 63)]
        public string Kind
        {
            get { return _kind; }
            set
            {
                if (_kind == value)
                {
                    return;
                }

                _kind = value;
                MakeDirty();
                NotifyOfPropertyChange();
            }
        }

        private double _price;

        [DoublePositiveValidation(ErrorMessage = "Price must be positive.")]
        public double Price
        {
            get { return _price;}
            set
            {
                if (Math.Abs(value - _price) < double.Epsilon)
                {
                    return;
                }
                _price = value;
                MakeDirty();
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => TotalCost);
            }
        }

        private int _quantity;

        [NumberValidation(Minimum = 0, ErrorMessage = "Quantity must be positive.")]
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity)
                {
                    return;
                }
                _quantity = value;
                MakeDirty();
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => TotalCost);
            }
        }

        [Obsolete("Remove after EditableModel fixed.")]
        public override string Error
        {
            get
            {
                var error = base.Error;

                if (string.IsNullOrEmpty(error))
                {
                    return error;
                }


                return error.Replace(Environment.NewLine, string.Empty);
            }
        }

        public double TotalCost
        {
            get { return _quantity*_price; }
        }
    }
}
