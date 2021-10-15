## The Basics

ABPaint is made up of **documents**. Each document is made up of **elements**, and each of these elements have a X, Y and Width and Height. Elements are described in more detail in their own section.

Documents have a pixel width and pixel height set by the user, This is designed to replicate bitmap programs that users are likely already familiar with.

Documents have a canvas. The **canvas** refers to the region of the document between the position (0, 0) and (pixel width, pixel height). Any element positioned within this region is considered be "in the canvas". At 100% zoom, the **canvas** will take up exactly "pixel width x pixel height" on the screen.

However, elements *can be* placed outside the canvas, outside the width and height, and these are known as **"canvas-masked"** elements, as they are being masked by the canvas. **Masking** refers to the final rendered image of an element being "cut off" in places. When elements are masked like this, there are two levels to the masking:

**Partially masked** - When an element is partially masked, and is viewed with the masking enabled, some of it is visible and the rest is masked.
**Fully masked** - When an element is fully masked, and is viewed with the masking enabled, none of it is visible.

This applies everywhere masking occurs, not just with canvas-masking.

## Elements

Elements are the fundamental building block of an ABSave document, so naturally they have a lot of specific rules and a very strict structure. There a lot of different types of elements, and it's designed to be extendable so new types of elements can be created at any time too. All element types can do the following things:

1. Contain a set of custom properties (in addition to the base properties), to define their appearance or cache info used when rendering or by the interface.
2. Defines custom rendering logic to "draw" them into the final displayed document.
3. Define custom interaction logic to customize how user interaction can be performed, and how it affects the properties and element.

All elements have the following base properties attached to them. Different elements can implement these in different ways, some may be auto-calculated, some may be controlled by the user, some may be stored when the element gets serialized (saved to a file/clipboard), that all depends on the type of element:

- `OffsetX` (double)
- `OffsetY` (double)
- `TotalWidth` (double)
- `TotalHeight` (double)
- `BoundingBox` (ElementBounds)
- `HasRotation` (double)
- `Rotation` (int)

The `OffsetX` and `OffsetY` is the offset where the element is positioned on the document.

The `TotalWidth` and `TotalHeight` is the total width and height of the element, right from one edge to another. The TotalWidth and TotalHeight should make a rectangle around the *entire* element, so if you have an element with a circle, it needs to make a rectangle around the entire circle. These values could be used by anything, they're primilarly used by the input system as a quick way to determine if the mouse is *roughly* within the range of an element, as well as being used for some UI highlights, like the scaling highlights.

However, the `TotalWidth` and `TotalHeight` only define a rough rectangle around the element. A more precise bounding box is set by the `BoundingBox` property. This property communicates a much more precise bounding box around the element, whatever shape it may be, that can be made up of many points and curves! The input system also uses this for a more detailed idea of whether an item is highlighted. There's a seperate section about how bounding boxes are defined.

Different types of elements can add their own properties on top of these base and can implement 

## Preview Mode

The user can, of course, edit properties on elements (change the position/size/fill etc.). And when they do this, the rendering to display that edit matters a lot. The simple approach would be to re-render absolutely everything everytime you edit a property on an element. However, there are some flaws with this approach. 

The most obvious flaw is when the user changes a property quick rapidly, which they can do extremely easily by just *dragging* an element around a lot with the visual editor. On a document with hundreds of elements, re-rendering everything can be quite expensive, which can cause a major problem when they're extremely rapidly changing the property. 

There's also a similar problem with calculated properties. Modifying properties may affect other (not user editable) properties. For example, changing the `TotalWidth` on a rectangle would change the `BoundingBox` too. Calculating these other properties could be extremely expensive and time-consuming, even when you don't really need them *immediately* to get a rough preview of the user's changes out.

So, to solve this, while you're changing a property, ABPaint enters into what's known as **preview mode**.

ABPaint enters "preview mode" anytime you change a property. How long it stays in preview mode depends a lot on how you changed it:

- If the user *directly* changed the property, via a UI properties panel (or some other means), that panel should trigger the preview mode, and you'll remain in it for a short period of time determined by ABPaint, just in case you change it again right after.
- If the user used the visual interface on top of the document (e.g. dragging it), preview mode typically lasts as long as that operation goes on. E.g. Until they release the dragging

When in preview mode, both rendering and auto-calculated property changes are affected. As described below.

#### Auto-Calculated Property Changes

Some properties change when another changes. These changes can sometimes be quite expensive to process, and aren't something you want to have rapidly be re-calculated. If an element doesn't need a property to be updated during preview mode, there's no reason to update it until preview mode is done and we're back to normal, and that's exactly what we do! A perfect example of this is `BoundingBox`, if our changes affect the bounding box, it doesn't actually need changing until we're done with preview mode. In fact, preview mode takes advantage of this to keep the bounding box in one place as a guide to the user.

If an element *needs* certain properties to be re-calculated in order to properly display the changes, then it is able to mark that property as needing to change, and change it as appropriate.

So, to solve this problem, these properties are not re-calculated while in preview mode. During preview mode, only the property you're changing, and properties specifically

#### Preview Mode Rendering

When in preview mode, the rendering system is essentially set to only re-render the affected elements. Everything else is pre-rendered to a bitmap. This allows the change to appear very rapidly. That is the rough idea. Although of course the exact implementation of that is really down to the rendering component.

The renderer also slightly changes *how* it renders the affected elements. Instead of calling the `Render` method on the elements, it calls the `RenderPreview` method, which may do exactly the same thing on most types of elements, or may go a slightly faster-but-less-accurate path, it really depends on the element. Some elements may implement `RenderPreview` in such a way that doesn't need the auto-calculated property changes, while `Render` does.

As soon as you leave preview mode, a proper re-render of everything is done. This happens *after* property re-calculations are done.

**For the distant future:**

It may be possible that one day ABPaint's renderer could become advanced enough that it can only render *exactly* what needs rendering, even more precisely, like so:

If you're changing the offset of an element, literally all that's going to be re-rendered is the position the element is rendered at. The element itself won't even be re-rendered, it will just cache the element's graphics as a bitmap, and then move that bitmap around, unless changing the `OffsetX` and `OffsetY` property actually affects how it renders. 

There's no need for this at the moment, but could be something for the future, or maybe could just be implemented if any elements need it.