<script setup>
import { ref } from "vue";
import Button from "primevue/button";
import InputText from "primevue/inputtext";
import IconField from "primevue/iconfield";
import InputIcon from "primevue/inputicon";
import { useToast } from "primevue/usetoast";
import Checkbox from "primevue/checkbox";

const toast = useToast();
const todos = ref([]);
const selectedCategories = ref([""]);
const form = ref([
  {
    key: null,
    todo: "",
    done: true,
  },
]);

const addTodo = () => {
  const newTodo = form.value;
  if (!newTodo.todo == "") {
    todos.value.push(newTodo);
    toast.add({
      severity: "success",
      summary: "Success Message",
      detail: "Todo Added",
      life: 3000,
    });
    form.value = ref([
      {
        todo: "",
      },
    ]);
  } else {
    toast.add({
      severity: "warn",
      summary: "Warn Message",
      detail: "Please input todo",
      life: 3000,
    });
  }
};
</script>

<template>
  <Toast></Toast>
  <div class="h-screen flex items-center justify-center">
    <div class="w-96 grid grid-cols-1 gap-2 place-content-center">
      <div class="card flex">
        <div class="flex flex-col gap-3">
          <div v-for="todo in todos" :key="todo.key" class="flex items-center">
            <Checkbox
              v-model="selectedCategories"
              :inputId="form.key"
              name="todo"
              :value="todo.todo"
              class="mr-3"
            />
            <label :for="todo.key">{{ todo.todo }}</label>
          </div>
        </div>
      </div>

      <IconField>
        <InputIcon>
          <i class="pi pi-plus-circle" />
        </InputIcon>
        <InputText v-model="form.todo" />
      </IconField>

      <Button label="Add Todo" @click="addTodo()" />
    </div>
  </div>
</template>
