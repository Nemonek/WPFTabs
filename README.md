# WPFTabs

### Consegna
La consegna richiede la realizzazione di un programma che, usando il framework Windows Presentation Foundation (<b>WPF</b>), crei, con l'uso del controllo <b>TabControl</b>, un minimo di 5 tab, schede, che implementino il codice sviluppato nei compiti "test": sono obbligatori <b>CollaTZ</b> e <b>Isogramma</b>; gli altri 3 o più sono a scelta.
<br>
### Soluzione
La soluzione qua caricata prevede, la creazione di 5 tab strutturate come rappresentato nell'immagine:
![immagine](https://github.com/Nemonek/WPFTabs/assets/127589992/28618111-503a-41ca-86bb-aac4119d7a28)
Ogni bottone 'avvia' è collegato ad un Even Handler, che, alla pressione, chiama una funzione chiamata startProgramName: nel caso in cui l'input non sia valido
verrà mostrato in output un messsaggio che chiede l'inserimento di dati corretti, mentre, nel caso in cui sia valido, verrà mostrato l'output del programma. Per quanto
riguarda il bottone di reset, anche lui è collegato ad un Event Handler, che, alla pressione, resetta l'input e l'output del relativo TabItem. <br>
In aggiunta, anche la casella di testo dell'input è collegata ad un Event Handler, il cui compito è gestire la pressione del tasto invio durante l'input: se viene premuto, viene chiamata la stessa funzione che verrebbe chiamata alla pressione del tasto 'avvia'.
<br>
### Codice
Il codice di ogni tab, sia XAML che C#, presenta una struttura pressochè identica alle altre tab: qui di seguito un esempio generico di codice XAML e C# dove ProgramName rappresenta il nome dell'algoritmo che si vuole implementare.
<br>
#### Interfaccia grafica (XAML)
L'interfaccia grafica di ogni tab è definita da una <b>Grid</b> di 4 righe e 4 colonne: nella prima riga sono posizionati i bottoni 'avvia' e 'reset'; nella seconda e nella 3 è collocata la descrizione dell'algoritmo collegato alla tab, mentre nella 4 sono presenti la casella di input e di output.
<br>
Il codice di ogni tab risulta quindi essere composto da 4 parti:
* Definizione delle righe e delle colonne della Grid
 ```XAML
  <Grid.RowDefinitions>
      <RowDefinition></RowDefinition> <!--Indice 0-->
      <RowDefinition></RowDefinition> <!--Indice 1-->
      <RowDefinition></RowDefinition> <!--Indice 2-->
      <RowDefinition></RowDefinition> <!--Indice 3-->
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
      <ColumnDefinition></ColumnDefinition> <!--Indice 0-->
      <ColumnDefinition></ColumnDefinition> <!--Indice 1-->
      <ColumnDefinition></ColumnDefinition> <!--Indice 2-->
      <ColumnDefinition></ColumnDefinition> <!--Indice 3-->
  </Grid.ColumnDefinitions>
 ```
* definizione dei bottoni 'avvia' e 'reset'
```XAML
  <Button Margin="15px" Width="100px" Grid.Row="0" Grid.Column="0" Click="StartProgramNameButtonPressEvent">Avvia</Button>
  <Button Margin="15px" Width="100px" Grid.Row="0" Grid.Column="1" Click="ResetProgramName">Reset</Button>
```
* descrizione dell'algoritmo;
```XAML
  <RichTextBox Grid.Column="0" Grid.Row="1" Grid.ColumnSpan="4" Grid.RowSpan="2" Margin="20 0 20 0" IsReadOnly="True">
      <FlowDocument>
          <Paragraph>
              # Descrizione dell'esercizio
              <LineBreak/>
              Lo scopo di questo esercizio è...
              <LineBreak/>
          </Paragraph>
      </FlowDocument>
  </RichTextBox>
```
* definizione delle caselle di input e output
```XAML
  <TextBlock VerticalAlignment="Top" Grid.Row="3" Grid.Column="0">Input: (Press enter or start button)</TextBlock>
  <TextBox VerticalAlignment="Center" Grid.Row="3" Grid.Column="0" x:Name="InputProgramName" Keyboard.PreviewKeyDown="ProgramName_EnterPressed"></TextBox>
  <TextBlock VerticalAlignment="Top" Grid.Row="3" Grid.Column="1" Grid.ColumnSpan="2">Output:</TextBlock>
  <TextBlock VerticalAlignment="Center" Grid.Row="3" Grid.Column="1" x:Name="OutputProgramName" Grid.ColumnSpan="2"></TextBlock>
```
#### Codice C#
Come il codice XAML, anche il codice C# presenta una struttura ben definita:
* Event Handler per la gestione del bottone 'avvia', la pressione di invio nella casella di input e del bottone 'reset'
```C#
  private void StartProgramNameButtonPressEvent(object sender, RoutedEventArgs e)
  {
      StartProgramName();
  }
  
  private void InputProgramName_EnterPressed(object sender, KeyEventArgs e)
  {
      if (e.Key == Key.Return)
      {
          StartProgramName();
      }
  }
  
  private void ResetAcronimo(object sender, RoutedEventArgs e)
  {
      InputAcronimo.Text = "";
      OutputAcronimo.Text = "";
  }
```
* funzione di avvio dell'algoritmo (gestisce anche la visualizzazione dell'output)
```C#
  private void StartProgramName()
  {
      string ProgramNameResult = ProgramName();
      if (AcronimoResult == "ErrorMessage")
          OutputAcronimo.Text = "ERROR: please insert a word!";
      OutputAcronimo.Text = AcronimoResult;
  }
```
ErrorMessage rappresenta il valore che si è deciso di far ritornare dalla funzione in caso di input invalido.
* la funzione contenente l'algoritmo da eseguire.
<br>
<br>
