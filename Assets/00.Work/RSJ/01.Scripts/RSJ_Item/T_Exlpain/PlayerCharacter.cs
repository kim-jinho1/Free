using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public ItemInfomation CurrentEquipWeapon; // �������� ȹ���� �� �ش� ������ ������ ���⿡ �־��ݴϴ�.

    public int HP;
    public int Attack;

    public ItemSO EquipWeapon;

    public void EquipItem(int itemID)
    {
        // ���⼭ DB���� ItemID�� Key�� ItemInfomation�� ã�� �� ����
        //var targetItem = WeaponDB.ItemIDItemSODictionary[itemID]; // �̰Ÿ� ���� ����

        if(WeaponDB.ItemIDItemSODictionary.TryGetValue(itemID, out var targetItem) == false)
        {
            Debug.LogError($"�߸��� Key {itemID}�� �Է��Ͽ����ϴ�!");
            // ���⼭ ������ ���� �α� �����ϴ� �ڵ带 ����ֽ��ϴ�
            return;
        }

        //EquipWeapon = targetItem;

        /*if(EquipWeapon != null)
        {
            Attack - EquipWeapon
        }
        Attack + targetItem 

           EquipWeapon = targetItem*/

    }

    public bool CompareItemGrade(ItemGrade targetGrade)
    {
        /*if(targetGrade <= EquipWeapon.Grade)
        {
            return true;
        }
        */
        return false;
    }
}
