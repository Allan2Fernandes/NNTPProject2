   M S B A M L   `   `   `  ????F  BNNTPProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NNTPProject.ViewNNTPProject.View  5      +    %NNTPProject.View.ShowArticlesListView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:NNTPProject.View     5      
???????.??5
      ?   ? RowDefinitions  5   
   ?? 5      $??5* ?6   6*   ?? 5      $??* ?6   6)    ? ColumnDefinitions 5   
   ?? 5      $??2* ?6   6,   ?? 5      $??* ?6   6+   ?? 5      $??* ?6   6+   .+?5   
   ?? -   5         ??Name$ ListOfGroups??5      $??0??6)   $??3??66   $??0??6J    ?? View 5      ?? 5      .P?5      ?? $??Header??6%    ?? Width$	 300??6]    ?? DisplayMemberBinding 65   ?? *Header+6k   ?? 5      $??
StartIndex??6%   $	 150??6e    69   ?? *
StartIndex+6s   ?? 5      $??EndIndex??6%   $	 150??6a    67   ?? *
EndIndex+6p   5      5      ?? 5   
   $??1??6   $??Display listgroup??6   ??6:   ?? *ChangeListGroupPageCMD+6g   ?? 5   
   $??1??6   $??1??6   $??Post Article??6.   ??6E   ?? *ChangePostArticlePageCMD+6t   ?? 5   
   $??1??6   $??2??6   $??Favourite Groups??6.   ??6I   ?? *ChangeFavouriteGroupsPageCMD+6|   5       5!      