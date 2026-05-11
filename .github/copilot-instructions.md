# GitHub Copilot Instructions for "I Cant Fix That" Mod

## Mod Overview and Purpose

"I Cant Fix That" is a mod for RimWorld designed to restrict pawns from repairing buildings, apparel, and weapons that they do not know how to build due to a lack of research. This reflects a more realistic narrative that a tribal colony should not possess the knowledge to effectively repair advanced technology and weaponry, such as solar panels or sniper rifles. 

The mod is compatible with several other popular repair mods and offers an option to block repairs based on the colony's tech level.

## Key Features and Systems

- **Repair Restriction**: Pawns can only repair items and buildings that correspond to research they have completed, promoting a more authentic gameplay experience.
- **Colony Tech-Level Settings**: An adjustable setting allows players to block repairs for items above their colony’s technological capability.
- **Compatibility**: Works seamlessly with a variety of other repair-related mods, including:
  - Fluffy Breakdowns
  - MendAndRecycle
  - Repair Workbench
  - Misc. Weapon Repair
  - And many more listed in the mod description.

## Coding Patterns and Conventions

- **Static Classes**: Most helper functionalities are implemented using static classes and methods for utility style operations.
- **Modular Design**: Each supported mod or feature has its own dedicated class file, making the codebase easily manageable and separable.
- **Naming Conventions**: Follows C# conventions for naming, with clear and descriptive names for classes and methods to indicate their purpose.

## XML Integration

The mod utilizes XML for defining and reading configuration settings corresponding to tech levels, repair permissions, and compatibility settings with other mods.

- XML files are structured with clear nodes representing different settings.
- Ensure the XML files are correctly placed in the `Defs` folder as required by RimWorld for XML integration.

## Harmony Patching

- **Harmony Integration**: Uses Harmony to intercept and modify base game methods to enforce repair restrictions based on research.
- **Patching Strategy**: Typically employs prefix and postfix patches to inject custom logic or override existing mechanisms related to repair tasks.

## Suggestions for Copilot

When using GitHub Copilot to contribute to or expand this mod, consider the following suggestions:

1. **New Compatibility Enhancements**: Copilot can suggest new patches or extensions to make the mod compatible with newly released repair mods.
  
2. **Debugging Assistance**: Leverage Copilot for identifying potential issues in Harmony patches, especially those with complex conditional logic.
  
3. **XML Management**: Use Copilot to rapidly generate and modify XML configuration files as the mod expands to include more settings or compatibility options.
  
4. **Code Refactoring**: With large static utility classes, Copilot might help suggest optimal ways to refactor and optimize code for performance and readability.
  
5. **Feature Expansion**: Development of new features, such as additional repair restriction logic, where Copilot can assist with initial boilerplate or pattern recognition for repeated logic across multiple classes.

By maintaining consistent coding practices and leveraging GitHub Copilot effectively, extensions to "I Cant Fix That" can be implemented smoothly and efficiently.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
