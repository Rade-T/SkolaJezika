   M S B A M L   `   `   `  ����  SkolaJezikaWPF*    $SkolaJezikaWPF.Windows.KurseviWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  KurseviWindow��5   	   $	��500��6   $	��500��6,   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgKursevi��5      $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $	��234��6j   $	��320��6w   6�   �� 5   
   -   5        $��bDodaj��5      $��	Dodavanje��6   $
��Left=�63   $��
335,12,0,0q�6N   $	��Top=�6b   $	��147��6z   6�   �� 5   
   -   5        $��bIzmeni��5      $��Izmena��6    $
��Left=�61   $��
335,37,0,0q�6L   $	��Top=�6`   $	��147��6x   6�   �� 5	   
   -   5        $��bObrisi��5	      $��Brisanje��6    $
��Left=�63   $	��Top=�6N   $	��147��6f   $��
335,62,0,0q�6r   6�   �� 5
   
   -   5        $��bZatvori��5
      $��Zatvori��6!   $
��Left=�63   $��335,437,0,0q�6N   $	��Top=�6c   $	��147��6{   6�   �� 5   
   $
��Left=�6   $��
10,249,0,0q�6/   $
��Wrap=�6C   $��Ucenici��6W   $	��Top=�6f   �� 5   
   -   5        $��	lbUcenici��5   [   $
��Left=�6l   $	��189��6�   $��
10,270,0,0q�6�   $	��Top=�6�   $	��320��6�   ��6   ��  �� ElementName$ 	dgKursevi�� �� Path$ SelectedItem.Ucenici�6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Pretraga��6C   $	��Top=�6S   $��
335,86,0,0q�6k   �� 5   
   -   5        $��
tbPretraga��5      $
��Left=�6$   $��23��6?   $��335,107,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��147��6�   6�   �� 5   
   $
��Left=�6   $��335,135,0,0q�6/   $
��Wrap=�6D   $��Pretrazi po��6X   $	��Top=�6k   	� 5   
   -   5        $��rbJezik��5   (    	� 	GroupName$ Izbor��6   $��Jezicima��67   $
��Left=�6J   $��335,156,0,0q�6e   $	��Top=�6z   6�   	� 5   
   -	   5        $��rbUcenik��5   (   $ Izbor��6   $��	Ucenicima��68   $
��Left=�6L   $��335,176,0,0q�6g   $	��Top=�6|   6�   	� 5   
   -
   5        $��rbIme��5   )   $ Ucenik��6   $��Po imenu��66   $
��Left=�6I   $��335,196,0,0q�6d   $	��Top=�6y   6�   	� 5   
   -   5        $��	rbPrezime��5   )   $ Ucenik��6   $��Po prezimenu��6:   $
��Left=�6Q   $��335,216,0,0q�6l   $	��Top=�6�   6�   	� 5   
   -   5        $��rbJMBG��5   )   $ Ucenik��6   $��Po JMBG��67   $
��Left=�6I   $��335,236,0,0q�6d   $	��Top=�6y   6�   5      5      