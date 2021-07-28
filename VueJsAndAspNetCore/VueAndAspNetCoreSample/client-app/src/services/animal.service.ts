import Animal from "../classes/animal";

export default class AnimalService {

    public readonly url = "api/animal";

    async get() {
        const r = await fetch(this.url);
        var results = await r.json() as Animal[];
        return results;
    }

    async post(animal: Animal) {
        const requestOptions = {
                method: "POST",
                headers: { 'Accept': 'application/json', "Content-Type": "application/json" },
                body: JSON.stringify({ name: animal.name })
            };
        const response = await fetch(this.url, requestOptions);
        return response;
    }
    async delete(name: string) {
        const requestOptions = {
            method: "DELETE",
            headers: { 'Accept': 'application/json', "Content-Type": "application/json" },
            body: JSON.stringify({ name: name })
        };
        const response = await fetch(this.url+"/"+name, requestOptions);
    }

     

}