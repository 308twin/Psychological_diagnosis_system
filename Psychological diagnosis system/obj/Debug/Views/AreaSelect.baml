   M S B A M L   `   `   `  ����Y  UPsychological diagnosis system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Psychological_diagnosis_system.Views$Psychological_diagnosis_system.Views  5      5    /Psychological_diagnosis_system.Views.AreaSelect   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Psychological_diagnosis_system.Views     5      .��5	      � -   5        $��Content��5	        � 	Resources  5
   
    �� 
TargetType �� BasedOn �� Property �� Value��%�   '��       7���� 5      " ��6   8   .�5      ��  � ��$ 0 0 10 0q�6+   6>   �� 5       � ��$ 60��6-   6:   5      5       � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ ComboBoxProvince��5   J   $��0��6    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ Id��6,   ��5   #   �� 	 �� Path$	 	Provinces�
 �� SelectedValue
 5   C   �� $	 Province� �� Mode$ TwoWay=�5      �� 5   
   -   5        $ ComboBoxCity��5   #   $��1��6   $
 Name��5      $ Id��6,   ��5   9   �� $	 SelectedItem.Child� �� ElementName$ ComboBoxProvince��
 5   C   �� $
	 City�$ TwoWay=�6v   �� 5   
   -   5        $ ComboBoxCounty��5   #   $��2��6   $
 Name��5      $ Id��6,   ��5   ;   �� $	 SelectedItem.Child�$ ComboBoxCity��
 5   C   �� $	 County�$ TwoWay=�6w   5      5      