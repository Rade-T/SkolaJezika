   M S B A M L   `   `   `  ����  SkolaJezikaWPF%    SkolaJezikaWPF.NastavniciWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NastavniciWindow��5   	   $	��600��6"   $	��500��6/   .��5      � $��0,0,-8,0q�6   .+�5   
   �� -   5        $��bDodaj��5      $��	Dodavanje��6   $
��Left=�63   $��
307,10,0,0q�6N   $	��Top=�6b   $	��173��6z   6�   �� 5   
   -   5        $��bIzmeni��5      $��Izmena��6    $
��Left=�61   $��
307,37,0,0q�6L   $	��Top=�6`   $	��173��6x    J� RenderTransformOrigin$ 
0.52,1.045&�6�   �� 5   
   -   5        $��bObrisi��5      $��Brisanje��6    $
��Left=�63   $��
307,64,0,0q�6N   $	��Top=�6b   $	��173��6z   6�   �� 5	   
   -   5        $��bZatvori��5	      $��Zatvori��6!   $
��Left=�63   $��405,538,0,0q�6N   $	��Top=�6c   $��75��6{   6�   &   System.Windows.Controls.DataGrid  5
   
   -   5        $��dgNastavnici��5
      $
��Left=�6'   $��	10,10,0,0q�6B   $	��Top=�6U   $	��227��6m   $	��292��6z   6�   �� 5   
   $
��Left=�6   $��
307,91,0,0q�6/   $
��Wrap=�6C   $��	Pretraga:��6W   $	��Top=�6h   �� 5   
   -   5        $��
tbPretraga��5      $
��Left=�6$   $��23��6?   $��307,112,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��173��6�   6�   �� 5   
   $
��Left=�6   $��310,140,0,0q�6/   $
��Wrap=�6D   $��Pretrazi po��6X   $	��Top=�6k   	� 5   
   -   5        $��rbIme��5      $��Imenu��6#   $
��Left=�63   $��310,160,0,0q�6N   $	��Top=�6c   6{   	� 5   
   -   5        $��	rbPrezime��5      $��	Prezimenu��6'   $
��Left=�6;   $	��Top=�6V   $��310,180,0,0q�6n   6�   	� 5   
   -	   5        $��rbJMBG��5      $
��JMBG��6$   $
��Left=�63   $	��Top=�6N   $��310,200,0,0q�6f   6{   �� 5   
   $
��Left=�6   $��
10,242,0,0q�6/   $
��Wrap=�6C   $$��Kursevi koje nastavnik predaje��6W   $	��Top=�6}   �� 5   
   -
   5        $��	lbKursevi��5      $
��Left=�6o   $	��130��6�   $��
10,263,0,0q�6�   $	��Top=�6�   $	��292��6�   ��6#   ��  �� ElementName$ dgNastavnici�� �� Path$ SelectedItem.Kursevi�6�   �� 5   
   $
��Left=�6   $��
10,398,0,0q�6/   $
��Wrap=�6C   $&�� Ucenici kojima nastavnik predaje��6W   $	��Top=�6   $ 0.433,0&�6�   �� 5   
   -   5        $��	lbUcenici��5      $
��Left=�6p   $	��130��6�   $��
10,419,0,0q�6�   $	��Top=�6�   $	��292��6�   ��6#   �� $ dgNastavnici��$ SelectedItem.Ucenici�6�   5      5      