# PipelineCore

PipelineCore is a lightweight, configuration-driven workflow execution engine designed for building composable, validated pipelines of stateless execution steps.

It provides a structured runtime for defining, validating, and executing ordered workflows using a shared execution context.

---

## Core Concepts

### PipelineDefinition (Immutable)

A static blueprint describing:

* Ordered list of execution steps
* Pipeline structure and behavior
* No runtime state

Once created, a PipelineDefinition is never modified during execution.

---

### PipelineExecution (Runtime Instance)

A single running instance of a pipeline. Responsible for:

* Materializing steps from the PipelineDefinition
* Maintaining execution state
* Owning the ExecutionContext
* Coordinating step execution

Each PipelineExecution is isolated and independent.

---

### ExecutionContext (Runtime Memory)

A key-value based shared state container scoped to a PipelineExecution.

Responsibilities:

* Stores input data from triggers
* Stores intermediate step outputs
* Enables inter-step communication

Conceptually namespaced (e.g., `order.id`, `payment.status`).

---

### Step

A stateless execution unit that:

* Reads from ExecutionContext
* Writes results back to ExecutionContext
* Declares required inputs and produced outputs via metadata

Steps are reusable and composable across pipelines.

---

## Execution Model

Pipeline execution follows a strictly sequential model:

1. PipelineExecution is created from a PipelineDefinition
2. ExecutionContext is initialized (often from trigger input)
3. Steps execute in defined order:

   * Validate required inputs exist in ExecutionContext
   * Execute step logic
   * Write outputs back into ExecutionContext
4. Execution continues until all steps complete or failure occurs
5. Controller is notif
