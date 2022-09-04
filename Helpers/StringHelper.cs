using System;

namespace Helpers
{
    public class StringHelper
    {
        // Gereksinimler
        // 1. Girilen ifadenin başındaki ve sonundaki fazla boşluklar silinmelidir.
        // 2. Girilen ifadenin içerisindeki fazla boşluklar silinmelidir.

        public static string FazlaBosluklariSil(string ifade)
        {
            string yanit = String.Empty;

            if (ifade != null && ifade.Length > 0)
            {
                char[] temp = null;
                char[] ifadeCharArray = ifade.ToCharArray();

                /**
                 * ifade.Trim() yerine kendim yazmak istiyorum
                 */


                for (int i = 0; i < ifadeCharArray.Length; i++)
                {
                    if (ifadeCharArray[i] == ' ') // baştaki boşlukları silme
                        continue;
                    if (ifadeCharArray[i] != ' ')
                    {
                        for (int j = 0; j < ifadeCharArray.Length; j++)
                        {
                            int index = ifadeCharArray.Length - (j + 1);

                            if (ifadeCharArray[index] == ' ')//sondaki boşlukları silme
                                continue;
                            if (ifadeCharArray[index] != ' ')
                            {
                                if (i == index)//tek bir tane karakter varsa
                                {
                                    temp = new char[] { ifadeCharArray[i] };
                                }
                                else
                                {
                                    int fazlabosluk = 0;
                                    for (int x = i; x <= index; x++)// ifade içi fazla boşlukları hesaplama
                                    {
                                        if (ifadeCharArray[x] == ' ' && ifadeCharArray[x + 1] == ' ')
                                            fazlabosluk++;
                                    }

                                    temp = new char[index - (i + fazlabosluk) + 1]; // ilk sayı sıfırdan başladığı için

                                    for (int y = i, z = 0; y <= index; y++)
                                    {
                                        if (ifadeCharArray[y] == ' ' && ifadeCharArray[y + 1] == ' ')//fazla boşluklar silme
                                            continue;
                                        else
                                            temp[z] = ifadeCharArray[y];

                                        z++;
                                    }

                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                if (temp != null)
                {
                    foreach (char c in temp)
                    {
                        yanit += c;
                    }
                }
            }
            else
                yanit = ifade;

            return yanit;
        }
    }
}
