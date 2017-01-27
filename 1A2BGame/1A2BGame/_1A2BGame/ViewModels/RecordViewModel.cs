using GameModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2BGame
{
    public class RecordViewModel: BindableBase
    {
        private ObservableCollection<Record> _recordList;
        public ObservableCollection<Record> RecordList
        {
            get { return _recordList; }
            set { SetProperty(ref _recordList, value); }
        }

        #region PropertyName
        private string _propertyName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string PropertyName
        {
            get { return this._propertyName; }
            set { this.SetProperty(ref this._propertyName, value); }
        }
        #endregion
        private Record recordListSelected;
        //SetProperty 內容一樣不改(相同一個物件)  如果不同會將(recordListSelected)直重設
        public Record RecordListSelected
        {
            get { return recordListSelected; }
            set { SetProperty(ref recordListSelected, value); }
        }

        public RecordViewModel(List<Record> Recordlist)
        {
            RecordList = new ObservableCollection<Record>(Recordlist);
        }
    }
}
