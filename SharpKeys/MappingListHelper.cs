using System.Collections;
using System.Windows.Forms;

namespace SharpKeys
{
	public class MappingListHelper
	{
		private void RemoveNullKeyOption(ref ListBox mapFromKeyList)
		{
			int nPos = 0;
			nPos = mapFromKeyList.FindString("-- Turn Key Off (00_00)");
			if (nPos > -1)
				mapFromKeyList.Items.RemoveAt(nPos);
		}

		private void RemoveAlreadyRemappedKeys(ref ListBox mapFromKeyList, ListView remappedKeysList)
		{
			int nPos = 0;
			for (int i = 0; i < remappedKeysList.Items.Count; i++)
			{
				nPos = mapFromKeyList.FindString(remappedKeysList.Items[i].Text);
				if (nPos > -1)
					mapFromKeyList.Items.RemoveAt(nPos);
			}
		}

		private void RemoveAlreadyRemappedKeysButTheSelected(ref ListBox mapFromKeyList, ListView remappedKeysList)
		{
			int nPos = 0;
			for (int i = 0; i < remappedKeysList.Items.Count; i++)
			{
				nPos = mapFromKeyList.FindString(remappedKeysList.Items[i].Text);
				if ((nPos > -1) && (remappedKeysList.Items[i].Text != remappedKeysList.SelectedItems[0].Text))
				{
					mapFromKeyList.Items.RemoveAt(nPos);
				}
			}
		}

		private void BuildMappingList(ref ListBox mapFromKeyList, ref ListBox mapToKeyList)
		{

			KeyboardMappingService keyboardMapping = new KeyboardMappingService();
			Hashtable keyboardScanCodeMap = keyboardMapping.GetFullMapping();

			IDictionaryEnumerator fullMapping = keyboardScanCodeMap.GetEnumerator();

			while (fullMapping.MoveNext() == true)
			{
				string availableKeyText = $"{fullMapping.Value} ({fullMapping.Key})";
				mapFromKeyList.Items.Add(availableKeyText);
				mapToKeyList.Items.Add(availableKeyText);
			}
		}

		public void GetAddMappingList(ListView remappedKeysList, ref ListBox mapFromKeyList, ref ListBox mapToKeyList)
		{
			this.BuildMappingList(ref mapFromKeyList, ref mapToKeyList);

			// remove the null setting for "From" since you can never have a null key to map
			this.RemoveNullKeyOption(ref mapFromKeyList);
			
			// Now remove any of the keys that have already been mapped in the list (can't double up on from's)
			this.RemoveAlreadyRemappedKeys(ref mapFromKeyList, remappedKeysList);
			
			// let C# sort the lists
			mapFromKeyList.Sorted = true;
			mapToKeyList.Sorted = true;
		}

		public void GetEditMappingList(ListView remappedKeysList, ref ListBox mapFromKeyList, ref ListBox mapToKeyList)
		{
			this.BuildMappingList(ref mapFromKeyList, ref mapToKeyList);

			// remove the null setting for "From" since you can never have a null key to map
			this.RemoveNullKeyOption(ref mapFromKeyList);

			// remove any of the existing from key mappings however, leave in the one that has currently
			// been selected!
			this.RemoveAlreadyRemappedKeysButTheSelected(ref mapFromKeyList, remappedKeysList);

			// let C# sort the lists
			mapFromKeyList.Sorted = true;
			mapToKeyList.Sorted = true;
		}
	}
}
