<template>
  <a-card>
    <a-card-meta title="URL Box" description="收录你喜欢的网址">
      <template #avatar>
        <a-avatar src="icons\box-48.png" />
      </template>
    </a-card-meta>
    <template #actions>
      <a-form
        :model="formState"
        :validate-messages="validateMessages"
        @finish="onFinish"
        style="padding: 10px"
      >
        <a-form-item
          name="name"
          :rules="[{ required: true, message: '请输入标题！' }]"
        >
          <a-input
            v-model:value="formState.name"
            placeholder="标题"
            autocomplete="off"
          />
        </a-form-item>
        <a-form-item
          name="url"
          :rules="[{ required: true, message: '请输入URL！' }]"
        >
          <a-input
            v-model:value="formState.url"
            placeholder="URL"
            autocomplete="off"
          />
        </a-form-item>
        <a-form-item
          name="tags"
          :rules="[{ required: true, message: '请输入标签！' }]"
        >
          <a-select
            v-model:value="formState.tags"
            mode="tags"
            style="width: 100%; text-align: left"
            placeholder="标签"
            @change="handleChange"
            :options="options"
            :listHeight="120"
          >
          </a-select>
        </a-form-item>
        <a-form-item name="des">
          <a-textarea
            v-model:value="formState.des"
            placeholder="描述"
            auto-size
            allow-clear
            :maxlength="999"
            show-count
            autocomplete="off"
          />
        </a-form-item>
        <a-form-item>
          <a-button type="primary" html-type="submit">
            <template #icon> <HeartOutlined /> </template>收录</a-button
          >
        </a-form-item>
      </a-form>
    </template>
  </a-card>
</template>
<script>
import { ref, defineComponent, reactive } from "vue";
import { message } from "ant-design-vue";
import { HeartOutlined } from "@ant-design/icons-vue";
import axios from "axios";

function getCookie(cname) {
  var name = cname + "=";
  var ca = document.cookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i].trim();
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

export default defineComponent({
  components: {
    HeartOutlined,
  },
  setup() {
    const options = ref([{}]);
    const validateMessages = {
      required: "请输入！",
    };
    const formState = reactive({
      name: "",
      url: "",
      tags: [],
      des: "",
    });
    const onFinish = (values) => {
      console.log("Success:", values);
      axios
        .post("http://82.157.96.191:5000/article", values)
        .then(function (response) {
          if (response.data.success == true) {
            message.success("收录成功！");
          }
          console.log(response);
        })
        .catch(function (error) {
          message.error("收录异常！");
          console.log(error);
        });
    };

    const handleChange = (value) => {
      console.log(`selected ${value}`);
    };

    return {
      formState,
      onFinish,
      validateMessages,
      handleChange,
      options,
    };
  },
  async mounted() {
    var name = getCookie("name");
    var url = getCookie("url");
    console.log("name:"+name);
    this.formState.name = name;
    this.formState.url = url;
    let tags = [];
    await axios.get("http://82.157.96.191:5000/tag").then(function (res) {
      if (res.data.success == true) {
        tags = JSON.parse(res.data.result);
      }
    });
    this.options = tags.map((i) => {
      return { value: i };
    });
  },
});
</script>
