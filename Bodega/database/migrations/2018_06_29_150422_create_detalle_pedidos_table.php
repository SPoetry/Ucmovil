<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateDetallePedidosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('detalle_pedidos', function (Blueprint $table) {
            $table->integer('pedido_id')->unsigned();
            $table->integer('producto_id');
            $table->integer('cantidad');
            $table->timestamps();
            $table->primary(['pedido_id', 'producto_id']);
            $table->foreign('pedido_id')->references('id_pedido')->on('pedidos');
            $table->foreign('producto_id')->references('id_producto')->on('inventarios');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('detalle_pedidos');
    }
}
