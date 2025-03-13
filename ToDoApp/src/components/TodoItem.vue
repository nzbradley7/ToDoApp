<script setup>
const props = defineProps({
    'name': String,
    'created': Date,
    'isCompleted': Boolean
})
</script>

<template>
    <div>
        <h4>
            <s v-if="isCompleted">{{ name }}</s>
            <span v-else>{{ name }}</span>
        </h4>
    </div>
    <div><p>{{ created }}</p></div>
</template>

<style scoped>

</style>
