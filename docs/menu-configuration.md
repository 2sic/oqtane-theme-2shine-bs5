# Menu Configuration

WIP



## Common Menus

### Top Level Menu, No Subpages

```json
{
  "start": "*",
  "depth": 0
}
```

equivalent to

```json
{
  "start": "*",
  "startLevel": 0,
  "depth": 0
}
```


### Top Level Menu, With one Level of Subpages

```json
{
  "start": "*",
  "depth": 1
}
```

### Side-Menu Showing the Current Page and Subpages

```json
{
  "start": ".",
  "depth": 1
}
```

### Sub-Menu Showing Subpages Only

```json
{
  "start": ".",
  "skip": 1,
  "depth": 0,
}
```

### Current Page, Siblings and Children

```json
{
  "start": ".",
  "startLevel": -1,
  "depth": 1,
}
```

### Sub-Menu Showing the Tree from Level 2 to the Current Page and Sub Pages

```json
{
  "start": ".",
  "startLevel": 2,
  "depth": 1,
}
```

