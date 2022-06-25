# TriangleBlazor

## [Program.cs](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Program.cs)
Entry point for blazor application to start. This is where additional services can be added to the website

## [index.razor](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Pages/Index.razor)
The page where the customer comes to for the first time.

This is also where the form is set up for triangle calculations.

Since it's in blazor, there is no need for JavaScript. This reduces the need to write everything twice

It is done in C# instead of JavaScript.


## [Components](https://github.com/timjo6789/TriangleBlazor/tree/master/TriangleBlazor/Components)
This is what enables the program to act more like React or Vue.js by making components in .razor files

### [Card.razor](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Components/Card.razor)
For example, this card is an adaptation of Bootstrap 4 Card but enabling a body pass-through for custom details

```razor
<Card Style="info">
    <CardHeader>
        This is a header
    </CardHeader>
    <CardTitle>
        This is a title
    </CardTitle>
    <CardContent>
        <p>This is a content</p>
    </CardContent>
</Card>
```
This is made possible with `RenderFragment` object. This is what will allows us to apply html, and css on both `<CardHeader>` and `@CardHeader` fragment.
`Style="info"` allows us to pass in variables for the card to use. With this flexibility with the power of C#, I am able to live update the page with backend-code.

### [Output.razor](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Components/Output.razor)
This is an example of a component using another component

It uses [Card.razor](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Components/Card.razor)

```razor
@code {
    [Parameter]
    public Triangle triangle { get; set; }
}
```
triangle is a live value, in other words, if triangle gets changed, it reflects the update on the front-end

### [NumberInput.razor](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Components/NumberInput.razor)
This is a live input that will keep the number in check for validation.

With this piece of code
```c#
    [Parameter]
    public double Value {
        get => _value;
        set
        {
            // value is a javascript value (not C#) but can be used with C# functions
            if (_value == value) return;
            value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            if (value < 0) value = 0.01;
            if (value >= 10000000000000) value = 10000000000000; // javascript number with decimal before it breaks down
            _value = value;
            ValueChanged.InvokeAsync(value);
        }
    }

    [Parameter]
    public EventCallback<double> ValueChanged { get; set; }
```
It enables me to databind a side of a triangle to this input

Just like this via `@bind-Value=`
```razor
<NumberInput InputName="Side A" @bind-Value="@triangle.SideA"/>
```

## Model

### [Triangle.cs](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/Model/Triangle.cs)
This file is currently stored in the model folder. And it gets imported automatically to other files via [_Inports.cs](https://github.com/timjo6789/TriangleBlazor/blob/master/TriangleBlazor/_Imports.razor) with `@using TriangleBlazor.Model`
