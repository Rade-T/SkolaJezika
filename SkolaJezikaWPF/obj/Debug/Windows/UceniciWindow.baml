   M S B A M L   `   `   `  ����  SkolaJezikaWPF*    $SkolaJezikaWPF.Windows.UceniciWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  UceniciWindow��5   	   $	��600��6   $	��500��6,   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgUcenici��5      $
��Left=�6$   $	��Top=�6?   $	��227��6W   $	��292��6d   $��	10,10,0,0q�6p   6�   �� 5   
   -   5        $��bDodaj��5      $��	Dodavanje��6   $
��Left=�63   $��
307,10,0,0q�6N   $	��Top=�6b   $	��175��6z   6�   �� 5   
   -   5        $��bIzmeni��5      $��Izmena��6    $
��Left=�61   $��
307,35,0,0q�6L   $	��Top=�6`   $	��175��6x   6�   �� 5	   
   -   5        $��bObrisi��5	      $��Brisanje��6    $
��Left=�63   $��
307,60,0,0q�6N   $	��Top=�6b   $	��175��6z   6�   �� 5
   
   -   5        $��bIzlaz��5
      $��Izlaz��6   $
��Left=�6/   $��307,527,0,0q�6J   $	��Top=�6_   $	��175��6w   6�   �� 5   
   $
��Left=�6   $��307,112,0,0q�6/   $
��Wrap=�6D   $��	Pretraga:��6X   $	��Top=�6i   �� 5   
   -   5        $��
tbPretraga��5      $
��Left=�6$   $��23��6?   $��307,132,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��175��6�   6�   �� 5   
   $
��Left=�6   $��307,160,0,0q�6/   $
��Wrap=�6D   $��Pretrazi po��6X   $	��Top=�6k   	� 5   
   -   5        $��rbIme��5      $��Imenu��6#   $
��Left=�63   $��307,181,0,0q�6N   $	��Top=�6c   6{   	� 5   
   -   5        $��	rbPrezime��5      $��	Prezimenu��6'   $
��Left=�6;   $��307,201,0,0q�6V   $	��Top=�6k   6�   	� 5   
   -	   5        $��rbJMBG��5      $
��JMBG��6$   $
��Left=�63   $��307,221,0,0q�6N   $	��Top=�6c   6{   �� 5   
   $
��Left=�6   $��
10,242,0,0q�6/   $
��Wrap=�6C   $!��Kursevi koje ucenik pohadja��6W   $	��Top=�6z   �� 5   
   -
   5        $��	lbKursevi��5      $
��Left=�6l   $	��130��6�   $��
10,263,0,0q�6�   $	��Top=�6�   $	��292��6�   ��6#   ��  �� ElementName$ 	dgUcenici�� �� Path$ SelectedItem.Kursevi�6�   �� 5   
   $
��Left=�6   $��
10,398,0,0q�6/   $
��Wrap=�6C   $��Uplate��6W   $	��Top=�6e    J� RenderTransformOrigin$ 0.433,0&�6}   �� 5   
   -   5        $��lbUplate��5      $
��Left=�6k   $	��130��6�   $��
10,419,0,0q�6�   $	��Top=�6�   $	��292��6�   ��6"   �� $ 	dgUcenici��$ SelectedItem.Uplate�6�   5      5      