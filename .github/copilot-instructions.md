# GitHub Copilot Instructions for RimWorld Mod: I Can't Fix That

## Mod Overview and Purpose

"I Can't Fix That" is a RimWorld mod that adds a realistic twist to the repair mechanics by preventing pawns from repairing buildings, apparel, and weapons if they lack the knowledge to construct these items. If an item hasn't been researched, it can still be used but not repaired, bringing a logical consistency to the game's universe. This mod aims to enrich the gameplay experience by introducing a research-dependent repair limitation, challenging players to expand their knowledge before maintaining high-tech equipment.

## Key Features and Systems

- **Research-Dependent Repairs:** Pawns cannot repair items they haven't learned to build. This features applies to all objects, requiring colonies to research before they can maintain certain technologies.
- **Tech-Level Restrictions:** Settings allow for repair restrictions based on the colony's technological level, ensuring low-tech colonies can't repair advanced equipment.
- **Mod Compatibility:** The mod is compatible with various other repair-related mods, enhancing its versatility within different gameplay setups. Supported mods include:
  - Fluffy Breakdowns
  - MendAndRecycle
  - Repair Workbench
  - Misc. Weapon Repair
  - Repairable Gear
  - Repair Items
  - Vanilla Factions Expanded - Ancients

## Coding Patterns and Conventions

- **Consistent Naming:** Use PascalCase for class and method names to maintain readability and consistency across the codebase.
- **Static Utility Classes:** Utilities or helpers should be placed in static classes for general accessibility and to avoid unnecessary class instantiation.
- **Internal Mod Structure:** Key components of the mod such as `ICantFixThatMod` and `ICantFixThatSettings` are contained within internal classes to encapsulate mod-specific logic.

## XML Integration

Utilize XML definitions for managing configuration data where applicable (e.g., definable settings in the mod configuration). XML files should be well-commented and structured following RimWorld’s XML schema conventions to ensure clarity and compatibility.

## Harmony Patching

- **Purpose:** Use Harmony patching to intercept and modify core game methods without altering the original codebase. This allows the mod to modify existing game behaviors, like repair capabilities.
- **Implementation:** Target specific methods related to repair logic, ensuring patches are unique and minimally invasive. Patches should respect game updates by checking game version compatibility.

## Suggestions for Copilot

- **Pattern Recognition:** Aid in maintaining consistent naming conventions and structuring new classes using existing patterns.
- **Efficiency Enhancements:** Provide suggestions for optimizing code paths, especially in frequently accessed methods (e.g., those checking research prerequisites for repairs).
- **Harmony Patching Assistance:** Suggest safe placements for prefixes and postfixes in Harmony patches, ensuring they align with the intended mod functionality.
- **Compatibility Linking:** Suggest checks and balances in code where multiple mods interact, enhancing stability and cross-mod relationships.
- **Documentation Suggestions:** Promote adding comments and documentation for complex code areas ensuring they are well-understood by any developer interacting with the mod's codebase.

By adhering to these detailed instructions, developers working on "I Can't Fix That" can ensure that their mod remains efficient, maintainable, and compatible with evolving gameplay and modding demands.
