<template>
    <div v-bind:class="[isLoading == false ? '' : 'disabled-block']" v-if="findPrice != null" class="container text-content">
        <div class="row justify-content-center">
            <div class="col-12 col-lg-8">
                <h3>Страница оплаты «{{findPrice.name}}»</h3>
                <form method="post" v-on:submit="paySoft">
                    <div class="form-group mt-3">
                        <label>Контактное имя</label><br />
                        <input v-model="contactName" class="form-control mt-3" placeholder="Введите Ваше имя" />
                        <span class="text-warning" asp-validation-for="contactName"></span>
                    </div>
                    <div class="form-group mt-3">
                        <label>Номер телефона</label><br />
                        <input v-model="contactPhone" class="form-control mt-3" asp-for="contactPhone" placeholder="Введите Ваш номер телефона" />
                        <span class="text-warning" asp-validation-for="contactPhone"></span>
                    </div>
                    <div class="form-group mt-3">
                        <label asp-for="description">Описание проекта</label><br />
                        <textarea v-model="description" rows="7" maxlength="3000" class="form-control mt-3" asp-for="description" placeholder="Введите Ваши проектные пожелания"></textarea>
                        <span class="text-warning" asp-validation-for="description"></span>
                    </div>
                    <div v-if="findPrice.idTypePrice == 2" class="form-group mt-3">
                        <label for="exampleFormControlSelect1">Количество рабочих дней</label>
                        <select v-model="selectedDays" class="form-control mt-3" id="exampleFormControlSelect1">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                            <option>7</option>
                            <option>8</option>
                            <option>9</option>
                            <option>10</option>
                        </select>
                    </div>
                    <div class="form-check mt-3 mb-1">
                        <input v-model="isEnabledOfferta" type="checkbox" class="form-check-input" id="exampleCheck2">
                        <label class="form-check-label" for="exampleCheck2">Я согласен с политикой <a target="_blank" asp-controller="Oferta" asp-action="Oferta">оферты</a></label>
                    </div>
                    <div style="border-top: 1px solid #bdbdbd !important" class="mt-3"></div>
                    <div class="mt-3 text-center">
                        <p>
                            Спасибо, что Вы выбрали нас! Сумма заказа составляет <b>{{getSum.toLocaleString()}}</b> рублей.
                            После оплаты мы с Вами свяжемся для дополнительного согласования
                        </p>
                        <p>{{findPrice.name}} - {{findPrice.description}}</p>
                    </div>
                    <input v-bind:class="[isEnabledOfferta == true ? '' : 'disabled-block']" class="btn btn-primary p-3 w-100 mt-3" type="submit" value="Перейти к оплате" />
                </form>
            </div>
        </div>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        name: "paymentcomponent",
        props: ['idprice'],
        data() {
            return {
                findPrice: null,
                selectedDays: 3,
                isEnabledOfferta: false,
                contactName: null,
                contactPhone: null,
                description: null,
                isLoading: false
            }
        },
        computed: {
            getSum: function () {
                if (this.findPrice.idTypePrice == 2) {
                    return this.findPrice.price1 * this.selectedDays
                }
                return this.findPrice.price1
            }
        },
        methods: {
            paySoft: function () {
                event.preventDefault()

                this.isLoading = true

                let obj = {
                    idPrice: this.findPrice.id,
                    idType: this.findPrice.idTypePrice,
                    description: this.description,
                    contactName: this.contactName,
                    contactPhone: this.contactPhone,
                    countDays: this.selectedDays
                }

                axios.post('/api/Payment/Pay', obj)
                    .then(response => {

                        window.location.href = response.data

                    }).catch(error => {
                        alert('Заполните все необходимые поля!')

                        this.isLoading = false
                    });
            },
        },
        mounted() {
            axios.get('/api/Price/getPrice', {
                params:
                {
                    idPrice: this.idprice
                }
            })
                .then(response => {
                    this.findPrice = response.data
                }).catch(error => {
                    alert('error id')
                });
        },
    }
</script>
