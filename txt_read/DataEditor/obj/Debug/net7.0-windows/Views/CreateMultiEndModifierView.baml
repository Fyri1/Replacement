   M S B A M L   `   `   `  ����E  ADataEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DataEditor.ViewsDataEditor.Views  5   	   1    +DataEditor.Views.CreateMultiEndModifierView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DataEditor.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 
ResizeMode$  NoResize=�5	   
    � Title$  CreateMultiEndModifierView��6    $	��380��6C   $	��600��6P   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��267* �6   �� 5      $
��262* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��2��6,   �� 5   
   -   5        $��TextBlockDescription��5   o       MaterialDesignBody2TextBlock#��[  6   $��1��6K   $
��Wrap=�6[   $��6��6�   $
��Left=�6�   $	��313��6�   -+Добавление по правилам.�� 5      ��1. Если слово заканчивается на "ss","x","z","ch","sh","o" добавим окончание "es","Es","ES"�� 5      pn2. Если слово заканчивается на "e" добавим окончание "r", "R","s","S".�� 5      hf3. Если будет другая буква, то - "s","S","ed","Ed","ED". Пример: Church123�� 5       Результат:�� 5"      	Church123�� 5$      
Churchs123�� 5&      
ChurchS123�� 5(      Churches123�� 5*      ChurchEs123�� 5,      ChurchES1235.      �� 5/   
   -   5         ��Name$ TextboxAddLine��5/   x    % !MaterialDesignFloatingHintTextBox#��[ 6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Окончание��6M   $��45��6�   $	��200��6�   $��0��6�   6�   �� 50   
   -   5        $ TextboxAddLine_Copy��50      #��[ 6   $% Замена Окончания��6M   $��45��6�   $	��200��6�   $��1��6�   6�   �� 52   
   -   5        $��CreateButton��52      $��30��6&   $	��200��62   $��Create��6>   $��2��6j   54      55      