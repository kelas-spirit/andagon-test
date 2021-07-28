<template>
    <div>
        <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-4">
                <form @submit.prevent="submit" class="form-inline">
                    <div class="form-group mx-sm-8 mb-2">
                        <button type="submit" :disabled="!animal.name" class="btn btn-primary">Create</button>
                        <input type="text" v-model="animal.name" class="form-control" style="width:300px; margin-left: 5px" placeholder="Type animal name"/>
                    </div>

                </form>
            </div>
            <div class="col-md-3"></div>
        </div>
       
        <br />

        <div style="position:center">
            <table align="center">
                <thead>
                    <tr>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="animalsTable">
                    <tr v-for="r in this.results">
                        <td style="text-align: left;">{{ r.name }}</td>
                        <td><button @click="remove(r.name)" class="btn btn-danger btn-sm">X</button></td>
                    </tr>
                </tbody>
            </table>
        </div>
       
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import AnimalService from '../services/animal.service';
    import Animal from "../classes/animal";
    export const animalService = new AnimalService();

    export default Vue.extend({
        
        data() {
           
        return {
            results: [] as Animal[],
            name: '',
            animal: new Animal()
        };
    },
        async created() {
            this.results = await animalService.get();       
        },
    methods: {
        async submit() {
            var response = await animalService.post(this.animal);
            if (!response.ok) {
                alert("animal is already in db");
            }
            this.results = await animalService.get();
        },
        remove: async function remove(e) {
            let confirmAction = confirm("Are you sure to execute this action?");
            if (confirmAction) {
                await animalService.delete(e);
                this.results = await animalService.get();
            }
        }
    }

});

</script>
